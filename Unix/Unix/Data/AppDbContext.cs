using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Unix.Data.Models.Academic;
using Unix.Data.Models.Auth;
using Unix.Data.Models.Campus;
using Unix.Data.Models.Content;
using Unix.Data.Models.Facilities;
using Unix.Data.Models.Logs;
using Unix.Data.Models.Projects;

namespace Unix.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<AdminProfile> AdminProfiles => Set<AdminProfile>();
        public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Section> Sections => Set<Section>();
        public DbSet<StudentSection> StudentSections => Set<StudentSection>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseAssignment> CourseAssignments => Set<CourseAssignment>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<InstructorCourse> InstructorCourses => Set<InstructorCourse>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Floor> Floors => Set<Floor>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<TableEntity> Tables => Set<TableEntity>();
        public DbSet<TableUsageHistory> TableUsageHistories => Set<TableUsageHistory>();
        public DbSet<RoomAvailability> RoomAvailabilities => Set<RoomAvailability>();
        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<MaintenanceRequest> MaintenanceRequests => Set<MaintenanceRequest>();
        public DbSet<LostAndFoundItem> LostAndFoundItems => Set<LostAndFoundItem>();
        public DbSet<Notifications> Notifications => Set<Notifications>();
        public DbSet<Announcement> Announcements => Set<Announcement>();
        public DbSet<StageDriver> StageDrivers => Set<StageDriver>();
        public DbSet<GraduationProject> GraduationProjects => Set<GraduationProject>();
        public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>();
        public DbSet<RoomPath> RoomPaths => Set<RoomPath>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<EmailVerificationCode> EmailVerificationCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Section → Department
            modelBuilder.Entity<Section>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Sections)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade); // ok to cascade here

            // StudentProfile → Section
            modelBuilder.Entity<StudentProfile>()
                .HasOne(sp => sp.Section)
                .WithMany(s => s.StudentProfiles)
                .HasForeignKey(sp => sp.SectionId)
                .OnDelete(DeleteBehavior.Cascade); // cascade deletion if section deleted

            // StudentProfile → Student
            modelBuilder.Entity<StudentProfile>()
                .HasOne(sp => sp.Student)
                .WithMany(s => s.StudentProfiles)
                .HasForeignKey(sp => sp.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // prevent multiple cascade paths

            modelBuilder.Entity<StudentSection>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSections)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // prevents multiple cascade paths

            modelBuilder.Entity<StudentSection>()
                .HasOne(ss => ss.Section)
                .WithMany(s => s.StudentSections)
                .HasForeignKey(ss => ss.SectionId)
                .OnDelete(DeleteBehavior.Cascade); // deleting a section removes related student-section entries


            // Schedule → Section
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Section)
                .WithMany()
                .HasForeignKey(s => s.SectionId)
                .OnDelete(DeleteBehavior.Restrict); // prevents SQL Server error
        }

    }
}
