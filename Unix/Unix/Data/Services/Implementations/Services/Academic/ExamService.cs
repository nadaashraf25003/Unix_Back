using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class ExamService : IExamService
    {
        private readonly AppDbContext _context;

        public ExamService(AppDbContext context)
        {
            _context = context;
        }

        // STUDENT EXAMS
        public async Task<List<ExamDto>> GetStudentExamsAsync(long userId)
        {
            var studentData = await _context.Students
                .Where(s => s.UserId == userId)
                .Select(s => new
                {
                    s.Stage,
                    SectionId = s.StudentProfiles
                        .Select(sp => sp.SectionId)
                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync();

            if (studentData == null || studentData.SectionId == 0)
                return new List<ExamDto>();

            return await _context.Exams
                .Where(e =>
                    e.SectionId == studentData.SectionId &&
                    e.Stage == studentData.Stage)
                .OrderBy(e => e.ExamDate)
                .ThenBy(e => e.StartTime)
                .Select(e => new ExamDto
                {
                    Id = e.Id,
                    CourseName = e.Course.CourseName,
                    ExamType = e.ExamType,
                    RoomCode = e.Room.RoomCode,
                    InstructorName = e.Instructor != null
                        ? e.Instructor.FullName
                        : null,
                    ExamDate = e.ExamDate,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateExamDto dto)
        {
            _context.Exams.Add(new Exam
            {
                CourseId = dto.CourseId,
                SectionId = dto.SectionId,
                RoomId = dto.RoomId,
                InstructorId = dto.InstructorId,
                Stage = dto.Stage,
                ExamDate = dto.ExamDate,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                ExamType = dto.ExamType,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(long id, CreateExamDto dto)
        {
            var exam = await _context.Exams.FindAsync(id)
                ?? throw new Exception("Exam not found");

            exam.CourseId = dto.CourseId;
            exam.SectionId = dto.SectionId;
            exam.RoomId = dto.RoomId;
            exam.InstructorId = dto.InstructorId;
            exam.Stage = dto.Stage;
            exam.ExamDate = dto.ExamDate;
            exam.StartTime = dto.StartTime;
            exam.EndTime = dto.EndTime;
            exam.ExamType = dto.ExamType;
            exam.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var exam = await _context.Exams.FindAsync(id)
                ?? throw new Exception("Exam not found");

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }
    }

}
