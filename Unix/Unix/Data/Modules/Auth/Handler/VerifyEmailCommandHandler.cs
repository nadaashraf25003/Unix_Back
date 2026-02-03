using MediatR;
using Microsoft.EntityFrameworkCore;
using Unix.Data.Models;
using Unix.Data.Models.Academic;
using Unix.Data.Models.Auth;
using Unix.Data.Modules.Auth.Commands;
using Unix.Data.Services.Interfaces.IRepository.Auth;
using Unix.Data.Static;

namespace Unix.Data.Modules.Auth.Handler
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, Unit>
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmailVerificationRepository _codeRepo;
        private readonly AppDbContext _context;

        public VerifyEmailCommandHandler(
            IUserRepository userRepo,
            IEmailVerificationRepository codeRepo,
            AppDbContext context)
        {
            _userRepo = userRepo;
            _codeRepo = codeRepo;
            _context = context;
        }

        public async Task<Unit> Handle(VerifyEmailCommand request, CancellationToken ct)
        {
            var temp = await _codeRepo.GetValidCodeAsync(request.Email, request.Code)
                       ?? throw new InvalidOperationException("Invalid or expired code");

            var existingUser = await _userRepo.GetByEmailAsync(temp.Email);
            if (existingUser != null)
                throw new InvalidOperationException("User already exists");

            // ✅ Start transaction
            using var transaction = await _context.Database.BeginTransactionAsync(ct);

            try
            {
                // 1️⃣ Create User
                var user = new User
                {
                    Name = temp.Name,
                    Email = temp.Email,
                    PasswordHash = temp.PasswordHash,
                    Role = temp.Role,
                    IsActive = temp.Role == UserRole.Student,
                    IsEmailVerified = true,
                    CreatedAt = DateTime.UtcNow,
                    DepartmentId = temp.DepartmentId,
                    Stage = temp.Stage
                };
                await _userRepo.AddAsync(user);
                await _context.SaveChangesAsync(ct); // user.Id populated

                // 2️⃣ Add related entities
                switch (temp.Role)
                {
                    case UserRole.Student:
                        // Get department
                        var dept = await _context.Departments.FindAsync(temp.DepartmentId);
                        if (dept == null) throw new InvalidOperationException("Department not found");

                        var student = new Student
                        {
                            UserId = user.Id,
                            DepartmentId = dept.Id,
                            Stage = temp.Stage,
                            User = user,
                            Department = dept
                        };
                        await _context.Students.AddAsync(student);
                        await _context.SaveChangesAsync(ct); // student.Id populated

                        // Get a default section (make sure exists)
                        var section = await _context.Sections.FirstOrDefaultAsync();
                        if (section == null) throw new InvalidOperationException("No sections exist");

                        var studentProfile = new StudentProfile
                        {
                            StudentId = student.Id,
                            Student = student,
                            SectionId = section.Id,
                            Section = section,
                            Semester = "Fall",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };
                        await _context.StudentProfiles.AddAsync(studentProfile);
                        break;

                    case UserRole.Admin:
                        var adminProfile = new AdminProfile
                        {
                            UserId = user.Id,
                            DepartmentId = temp.DepartmentId,
                            CreatedAt = DateTime.UtcNow,
                            User = user
                        };
                        await _context.AdminProfiles.AddAsync(adminProfile);
                        break;

                    case UserRole.Instructor:
                        var instrDept = await _context.Departments.FindAsync(temp.DepartmentId);
                        if (instrDept == null) throw new InvalidOperationException("Department not found");

                        var instructor = new Instructor
                        {
                            FullName = user.Name,
                            Email = user.Email,
                            DepartmentId = instrDept.Id,
                            Department = instrDept
                        };
                        await _context.Instructors.AddAsync(instructor);
                        break;
                }

                // 3️⃣ Mark code as used
                temp.IsUsed = true;
                await _codeRepo.UpdateAsync(temp);

                // 4️⃣ Save all
                await _context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);

                return Unit.Value;
            }
            catch
            {
                await transaction.RollbackAsync(ct);
                throw; // check inner exception for exact EF error
            }
        }
    }
}
