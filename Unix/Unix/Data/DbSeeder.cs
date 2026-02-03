using System;
using System.Collections.Generic;
using System.Linq;
using Unix.Data.Models;
using Unix.Data.Models.Academic;
using Unix.Data.Models.Auth;
using Unix.Data.Models.Campus;
using Unix.Data.Models.Content;
using Unix.Data.Models.Facilities;
using Unix.Data.Models.Logs;
using Unix.Data.Models.Projects;
using Unix.Data.Static;

namespace Unix.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // ==========================
            // 1️⃣ Departments
            if (!context.Departments.Any())
            {
                var departments = new List<Department>
                {
                    new Department { Name = "Computer Engineering", Code = "CENG" },
                    new Department { Name = "Electronics", Code = "ELC" },
                    new Department { Name = "Mechanical", Code = "MECH" },
                    new Department { Name = "Civil", Code = "CIV" },
                    new Department { Name = "Architecture", Code = "ARCH" }
                };
                context.Departments.AddRange(departments);
                context.SaveChanges();
            }

            // ==========================
            // 2️⃣ Sections
            if (!context.Sections.Any())
            {
                var sections = new List<Section>
                {
                    new Section { Name = "CENG-1A", DepartmentId = 1, Stage = 1 },
                    new Section { Name = "CENG-2A", DepartmentId = 1, Stage = 2 },
                    new Section { Name = "ELC-1A", DepartmentId = 2, Stage = 1 },
                    new Section { Name = "ELC-2A", DepartmentId = 2, Stage = 2 },
                    new Section { Name = "MECH-1A", DepartmentId = 3, Stage = 1 }
                };
                context.Sections.AddRange(sections);
                context.SaveChanges();
            }

            // ==========================
            // 3️⃣ Users
            //if (!context.Users.Any())
            //{
            //    var users = new List<User>
            //    {
            //        new User { Name = "Alice Ahmed", Email = "alice@example.com", PasswordHash = "hashedpassword1", Role = 0, IsActive = true, CreatedAt = DateTime.UtcNow },
            //        new User { Name = "Bob Samir", Email = "bob@example.com", PasswordHash = "hashedpassword2", Role = 0, IsActive = true, CreatedAt = DateTime.UtcNow },
            //        new User { Name = "Carol Nabil", Email = "carol@example.com", PasswordHash = "hashedpassword3", Role = 0 , IsActive = true, CreatedAt = DateTime.UtcNow },
            //        new User { Name = "David Hany", Email = "david@example.com", PasswordHash = "hashedpassword4", Role =0, IsActive = true, CreatedAt = DateTime.UtcNow },
            //        new User { Name = "Eman Fawzy", Email = "eman@example.com", PasswordHash = "hashedpassword5", Role = 0, IsActive = true, CreatedAt = DateTime.UtcNow }
            //    };
            //    context.Users.AddRange(users);
            //    context.SaveChanges();
            //}

            // ==========================
            // 4️⃣ Students
            //if (!context.Students.Any())
            //{
            //    var students = new List<Student>
            //    {
            //        new Student { UserId = 1, DepartmentId = 1, Stage = 1 },
            //        new Student { UserId = 2, DepartmentId = 1, Stage = 2 },
            //        new Student { UserId = 3, DepartmentId = 2, Stage = 1 },
            //        //new Student { UserId = 5, DepartmentId = 2, Stage = 2 },
            //        //new Student { UserId = 4, DepartmentId = 3, Stage = 1 }
            //    };
            //    context.Students.AddRange(students);
            //    context.SaveChanges();
            //}

            // ==========================
            // 5️⃣ StudentProfiles
            //if (!context.StudentProfiles.Any())
            //{
            //    var profiles = new List<StudentProfile>
            //    {
            //        new StudentProfile { StudentId = 1, SectionId = 1, Semester = "Fall", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            //        new StudentProfile { StudentId = 2, SectionId = 2, Semester = "Spring", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            //        new StudentProfile { StudentId = 3, SectionId = 3, Semester = "Fall", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            //        //new StudentProfile { StudentId = 4, SectionId = 4, Semester = "Spring", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            //        //new StudentProfile { StudentId = 5, SectionId = 5, Semester = "Fall", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            //    };
            //    context.StudentProfiles.AddRange(profiles);
            //    context.SaveChanges();
            //}

            // ==========================
            // 6️⃣ Courses
            if (!context.Courses.Any())
            {
                var courses = new List<Course>
                {
                    new Course { CourseName = "Programming 101", CourseCode = "CENG101" },
                    new Course { CourseName = "Data Structures", CourseCode = "CENG102" },
                    new Course { CourseName = "Digital Electronics", CourseCode = "ELC101" },
                    new Course { CourseName = "Circuit Analysis", CourseCode = "ELC102" },
                    new Course { CourseName = "Thermodynamics", CourseCode = "MECH101" }
                };
                context.Courses.AddRange(courses);
                context.SaveChanges();
            }

            // ==========================
            // 7️⃣ CourseAssignments
            if (!context.CourseAssignments.Any())
            {
                var assignments = new List<CourseAssignment>
                {
                    new CourseAssignment { CourseId = 1, SectionId = 1 },
                    new CourseAssignment { CourseId = 2, SectionId = 1 },
                    new CourseAssignment { CourseId = 3, SectionId = 3 },
                    new CourseAssignment { CourseId = 4, SectionId = 4 },
                    new CourseAssignment { CourseId = 5, SectionId = 5 }
                };
                context.CourseAssignments.AddRange(assignments);
                context.SaveChanges();
            }

            // ==========================
            // 8️⃣ Instructors
            //if (!context.Instructors.Any())
            //{
            //    var instructors = new List<Instructor>
            //    {
            //        new Instructor { FullName = "David Hany", Email = "david@example.com", DepartmentId = 1 },
            //        //new Instructor { FullName = "Eman Fawzy", Email = "eman@example.com", DepartmentId = 1 },
            //        //new Instructor { FullName = "Fady Karim", Email = "fady@example.com", DepartmentId = 2 },
            //        //new Instructor { FullName = "Ghada Tamer", Email = "ghada@example.com", DepartmentId = 2 },
            //        //new Instructor { FullName = "Hossam Ali", Email = "hossam@example.com", DepartmentId = 3 }
            //    };
            //    context.Instructors.AddRange(instructors);
            //    context.SaveChanges();
            //}

            // ==========================
            // 9️⃣ InstructorCourses
            //if (!context.InstructorCourses.Any())
            //{
            //    var icourses = new List<InstructorCourse>
            //    {
            //        new InstructorCourse { InstructorId = 1, CourseId = 1 },
            //        new InstructorCourse { InstructorId = 1, CourseId = 2 },
            //        new InstructorCourse { InstructorId = 1, CourseId = 3 },
            //        //new InstructorCourse { InstructorId = 4, CourseId = 4 },
            //        //new InstructorCourse { InstructorId = 5, CourseId = 5 }
            //    };
            //    context.InstructorCourses.AddRange(icourses);
            //    context.SaveChanges();
            //}

            // ==========================
            // 10️⃣ Schedules
            //if (!context.Schedules.Any())
            //{
            //    var schedules = new List<Schedule>
            //    {
            //        new Schedule { CourseId = 1, SectionId = 1, RoomId = 1, InstructorId = 1, DayOfWeek = "Monday", StartTime = new TimeSpan(8,0,0), EndTime = new TimeSpan(10,0,0) },
            //        //new Schedule { CourseId = 2, SectionId = 1, RoomId = 2, InstructorId = 2, DayOfWeek = "Tuesday", StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(12,0,0) },
            //        //new Schedule { CourseId = 3, SectionId = 3, RoomId = 3, InstructorId = 3, DayOfWeek = "Wednesday", StartTime = new TimeSpan(8,0,0), EndTime = new TimeSpan(10,0,0) },
            //        //new Schedule { CourseId = 4, SectionId = 4, RoomId = 4, InstructorId = 4, DayOfWeek = "Thursday", StartTime = new TimeSpan(12,0,0), EndTime = new TimeSpan(14,0,0) },
            //        //new Schedule { CourseId = 5, SectionId = 5, RoomId = 5, InstructorId = 5, DayOfWeek = "Friday", StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(12,0,0) }
            //    };
            //    context.Schedules.AddRange(schedules);
            //    context.SaveChanges();
            //}

            // ==========================
            // 11️⃣ Exams
            //if (!context.Exams.Any())
            //{
            //    var exams = new List<Exam>
            //    {
            //        new Exam { CourseId = 1, SectionId = 1, RoomId = 1, InstructorId = 1, Stage = 1, ExamDate = DateTime.UtcNow.AddDays(5), StartTime = new TimeSpan(9,0,0), EndTime = new TimeSpan(11,0,0), ExamType = "Quiz", CreatedAt = DateTime.UtcNow },
            //        //new Exam { CourseId = 2, SectionId = 1, RoomId = 2, InstructorId = 2, Stage = 1, ExamDate = DateTime.UtcNow.AddDays(6), StartTime = new TimeSpan(13,0,0), EndTime = new TimeSpan(15,0,0), ExamType = "Midterm", CreatedAt = DateTime.UtcNow },
            //        //new Exam { CourseId = 3, SectionId = 3, RoomId = 3, InstructorId = 3, Stage = 1, ExamDate = DateTime.UtcNow.AddDays(7), StartTime = new TimeSpan(9,0,0), EndTime = new TimeSpan(11,0,0), ExamType = "Quiz", CreatedAt = DateTime.UtcNow },
            //        //new Exam { CourseId = 4, SectionId = 4, RoomId = 4, InstructorId = 4, Stage = 2, ExamDate = DateTime.UtcNow.AddDays(8), StartTime = new TimeSpan(10,0,0), EndTime = new TimeSpan(12,0,0), ExamType = "Final", CreatedAt = DateTime.UtcNow },
            //        //new Exam { CourseId = 5, SectionId = 5, RoomId = 5, InstructorId = 5, Stage = 2, ExamDate = DateTime.UtcNow.AddDays(9), StartTime = new TimeSpan(11,0,0), EndTime = new TimeSpan(13,0,0), ExamType = "Midterm", CreatedAt = DateTime.UtcNow }
            //    };
            //    context.Exams.AddRange(exams);
            //    context.SaveChanges();
            //}

            // ==========================
            // 12️⃣ StageDrivers
            if (!context.StageDrivers.Any())
            {
                var stageDrivers = new List<StageDriver>
                {
                    new StageDriver { Stage = 1, DepartmentId = 1, Title = "Intro to Programming", Type = "Lecture Notes", Link = "https://link1.com", CreatedAt = DateTime.UtcNow },
                    new StageDriver { Stage = 1, DepartmentId = 2, Title = "Basic Electronics", Type = "Lecture Notes", Link = "https://link2.com", CreatedAt = DateTime.UtcNow },
                    new StageDriver { Stage = 2, DepartmentId = 1, Title = "Data Structures Guide", Type = "PDF", Link = "https://link3.com", CreatedAt = DateTime.UtcNow },
                    new StageDriver { Stage = 2, DepartmentId = 2, Title = "Circuits Lab", Type = "PDF", Link = "https://link4.com", CreatedAt = DateTime.UtcNow },
                    new StageDriver { Stage = 1, DepartmentId = 3, Title = "Thermodynamics Notes", Type = "Lecture Notes", Link = "https://link5.com", CreatedAt = DateTime.UtcNow }
                };
                context.StageDrivers.AddRange(stageDrivers);
                context.SaveChanges();
            }

            // ==========================
            // 13️⃣ GraduationProjects
            if (!context.GraduationProjects.Any())
            {
                var projects = new List<GraduationProject>
                {
                    new GraduationProject { ProjectName = "Smart Campus System", CreatedAt = DateTime.UtcNow },
                    new GraduationProject { ProjectName = "AI Chatbot", CreatedAt = DateTime.UtcNow },
                    new GraduationProject { ProjectName = "IoT Plant Watering", CreatedAt = DateTime.UtcNow },
                    new GraduationProject { ProjectName = "E-commerce Web App", CreatedAt = DateTime.UtcNow },
                    new GraduationProject { ProjectName = "Robotic Arm", CreatedAt = DateTime.UtcNow }
                };
                context.GraduationProjects.AddRange(projects);
                context.SaveChanges();
            }

            // ==========================
            // 14️⃣ ProjectMembers
            //if (!context.ProjectMembers.Any())
            //{
            //    var members = new List<ProjectMember>
            //{
            //    new ProjectMember { ProjectId = 1, StudentId = 1, CreatedAt = DateTime.UtcNow },
            //    new ProjectMember { ProjectId = 1, StudentId = 2, CreatedAt = DateTime.UtcNow },
            //    new ProjectMember { ProjectId = 2, StudentId = 3, CreatedAt = DateTime.UtcNow },
            //    //new ProjectMember { ProjectId = 3, StudentId = 4, CreatedAt = DateTime.UtcNow },
            //    //new ProjectMember { ProjectId = 4, StudentId = 5, CreatedAt = DateTime.UtcNow }
            //};
            //    context.ProjectMembers.AddRange(members);
            //    context.SaveChanges();
            //}

            // ==========================
            // 15️⃣ Buildings
            if (!context.Buildings.Any())
            {
                var buildings = new List<Building>
                {
                    new Building { Name = "Main Building", Description = "Administration & Classrooms" },
                    new Building { Name = "Engineering Block", Description = "Labs and Lecture Halls" },
                    new Building { Name = "Science Block", Description = "Physics and Chemistry Labs" },
                    new Building { Name = "Library", Description = "Books and Study Area" },
                    new Building { Name = "Auditorium", Description = "Events and Conferences" }
                };
                            context.Buildings.AddRange(buildings);
                context.SaveChanges();
            }

            // ==========================
            // 16️⃣ Floors
            if (!context.Floors.Any())
            {
                var floors = new List<Floor>
            {
                new Floor { BuildingId = 1, FloorNumber = 1 },
                new Floor { BuildingId = 1, FloorNumber = 2 },
                new Floor { BuildingId = 2, FloorNumber = 1 },
                new Floor { BuildingId = 2, FloorNumber = 2 },
                new Floor { BuildingId = 3, FloorNumber = 1 }
            };
                context.Floors.AddRange(floors);
                context.SaveChanges();
            }

            // ==========================
            // 18️⃣ TableEntity
            if (!context.Tables.Any())
            {
                var tables = new List<TableEntity>
                {
                    new TableEntity { RoomId = 1, TableNumber = 1, IsOccupied = false, LastUpdated = DateTime.UtcNow },
                    new TableEntity { RoomId = 1, TableNumber = 2, IsOccupied = true, LastUpdated = DateTime.UtcNow },
                    new TableEntity { RoomId = 2, TableNumber = 1, IsOccupied = false, LastUpdated = DateTime.UtcNow },
                    new TableEntity { RoomId = 3, TableNumber = 1, IsOccupied = false, LastUpdated = DateTime.UtcNow },
                    new TableEntity { RoomId = 3, TableNumber = 2, IsOccupied = true, LastUpdated = DateTime.UtcNow }
                };
                context.Tables.AddRange(tables);
                context.SaveChanges();
            }

            // ==========================
            // 19️⃣ TableUsageHistory
            //if (!context.TableUsageHistories.Any())
            //{
            //    var usageHistory = new List<TableUsageHistory>
            //    {
            //        new TableUsageHistory { TableId = 1, UserId = 1, StartTime = DateTime.UtcNow.AddHours(-2), EndTime = DateTime.UtcNow },
            //        new TableUsageHistory { TableId = 2, UserId = 2, StartTime = DateTime.UtcNow.AddHours(-3), EndTime = DateTime.UtcNow.AddHours(-1) },
            //        new TableUsageHistory { TableId = 3, UserId = 3, StartTime = DateTime.UtcNow.AddHours(-1), EndTime = DateTime.UtcNow },
            //        new TableUsageHistory { TableId = 4, UserId = 4, StartTime = DateTime.UtcNow.AddHours(-4), EndTime = DateTime.UtcNow.AddHours(-2) },
            //        new TableUsageHistory { TableId = 5, UserId = 5, StartTime = DateTime.UtcNow.AddHours(-5), EndTime = DateTime.UtcNow.AddHours(-3) }
            //    };
            //    context.TableUsageHistories.AddRange(usageHistory);
            //    context.SaveChanges();
            //}

            // ==========================
            // 20️⃣ RoomAvailability
            if (!context.RoomAvailabilities.Any())
            {
                var availabilities = new List<RoomAvailability>
                {
                    new RoomAvailability { RoomId = 1, DayOfWeek = "Monday", StartTime = new TimeOnly(8,0), EndTime = new TimeOnly(10,0), IsAvailable = true },
                    new RoomAvailability { RoomId = 1, DayOfWeek = "Monday", StartTime = new TimeOnly(10,0), EndTime = new TimeOnly(12,0), IsAvailable = false },
                    new RoomAvailability { RoomId = 2, DayOfWeek = "Tuesday", StartTime = new TimeOnly(8,0), EndTime = new TimeOnly(10,0), IsAvailable = true },
                    new RoomAvailability { RoomId = 3, DayOfWeek = "Wednesday", StartTime = new TimeOnly(9,0), EndTime = new TimeOnly(11,0), IsAvailable = true },
                    new RoomAvailability { RoomId = 4, DayOfWeek = "Thursday", StartTime = new TimeOnly(10,0), EndTime = new TimeOnly(12,0), IsAvailable = false }
                };
                            context.RoomAvailabilities.AddRange(availabilities);
                context.SaveChanges();
            }

            // ==========================
            // 21️⃣ Equipment
            if (!context.Equipment.Any())
            {
                var equipments = new List<Equipment>
                {
                    new Equipment { Name = "Projector", RoomId = 1, Quantity = 1 },
                    new Equipment { Name = "Whiteboard", RoomId = 1, Quantity = 2 },
                    new Equipment { Name = "PC", RoomId = 2, Quantity = 10 },
                    new Equipment { Name = "Oscilloscope", RoomId = 2, Quantity = 5 },
                    new Equipment { Name = "Printer", RoomId = 3, Quantity = 1 }
                };
                            context.Equipment.AddRange(equipments);
                context.SaveChanges();
            }

            // ==========================
            // 22️⃣ MaintenanceRequest
            //if (!context.MaintenanceRequests.Any())
            //{
            //                var maintenance = new List<MaintenanceRequest>
            //    {
            //        new MaintenanceRequest { RoomId = 1, Issue = "Projector not working", ReportedById = 1, Status = "Pending", CreatedAt = DateTime.UtcNow },
            //        new MaintenanceRequest { RoomId = 2, Issue = "Air conditioning", ReportedById = 2, Status = "InProgress", CreatedAt = DateTime.UtcNow },
            //        new MaintenanceRequest { RoomId = 3, Issue = "Broken chair", ReportedById = 3, Status = "Completed", CreatedAt = DateTime.UtcNow },
            //        new MaintenanceRequest { RoomId = 4, Issue = "Light bulb", ReportedById = 4, Status = "Pending", CreatedAt = DateTime.UtcNow },
            //        new MaintenanceRequest { RoomId = 5, Issue = "Door handle", ReportedById = 5, Status = "Pending", CreatedAt = DateTime.UtcNow }
            //    };
            //                context.MaintenanceRequests.AddRange(maintenance);
            //    context.SaveChanges();
            //}

            // ==========================
            // 23️⃣ LostAndFoundItem
            //if (!context.LostAndFoundItems.Any())
            //{
            //    var lostFound = new List<LostAndFoundItem>
            //    {
            //        new LostAndFoundItem { ItemName = "Wallet", ItemType = "Personal", Location = "Library", Date = DateOnly.FromDateTime(DateTime.UtcNow), ContactInfo = "alice@example.com", ReportedById = 1, IsResolved = false },
            //        new LostAndFoundItem { ItemName = "USB Drive", ItemType = "Electronic", Location = "Lab 1", Date = DateOnly.FromDateTime(DateTime.UtcNow), ContactInfo = "bob@example.com", ReportedById = 2, IsResolved = false },
            //        new LostAndFoundItem { ItemName = "Keys", ItemType = "Personal", Location = "Cafeteria", Date = DateOnly.FromDateTime(DateTime.UtcNow), ContactInfo = "carol@example.com", ReportedById = 3, IsResolved = false },
            //        new LostAndFoundItem { ItemName = "Notebook", ItemType = "Stationery", Location = "Lecture Hall 1", Date = DateOnly.FromDateTime(DateTime.UtcNow), ContactInfo = "david@example.com", ReportedById = 4, IsResolved = true },
            //        new LostAndFoundItem { ItemName = "Headphones", ItemType = "Electronic", Location = "Lab 2", Date = DateOnly.FromDateTime(DateTime.UtcNow), ContactInfo = "eman@example.com", ReportedById = 5, IsResolved = false }
            //    };
            //    context.LostAndFoundItems.AddRange(lostFound);
            //    context.SaveChanges();
            //}

            // ==========================
            // 24️⃣ Announcements
            //if (!context.Announcements.Any())
            //{
            //    var announcements = new List<Announcement>
            //    {
            //        new Announcement { Title = "Semester Start", Content = "New semester starts next Monday", CreatedById = 3, CreatedAt = DateTime.UtcNow },
            //        new Announcement { Title = "Lab Closure", Content = "Lab 2 closed for maintenance", CreatedById = 3, CreatedAt = DateTime.UtcNow },
            //        new Announcement { Title = "Exam Schedule", Content = "Midterm schedule released", CreatedById = 3, CreatedAt = DateTime.UtcNow },
            //        new Announcement { Title = "Guest Lecture", Content = "AI lecture on Friday", CreatedById = 4, CreatedAt = DateTime.UtcNow },
            //        new Announcement { Title = "Library Hours", Content = "Extended library hours during exams", CreatedById = 3, CreatedAt = DateTime.UtcNow }
            //    };
            //    context.Announcements.AddRange(announcements);
            //    context.SaveChanges();
            //}

            // ==========================
            // 25️⃣ Notifications
            //if (!context.Notifications.Any())
            //{
            //    var notifications = new List<Notifications>
            //{
            //    new Notifications { UserId = 1, Message = "Your project group has been updated.", IsRead = false, CreatedAt = DateTime.UtcNow },
            //    new Notifications { UserId = 2, Message = "New exam schedule available.", IsRead = false, CreatedAt = DateTime.UtcNow },
            //    new Notifications { UserId = 3, Message = "Admin announcement posted.", IsRead = true, CreatedAt = DateTime.UtcNow },
            //    new Notifications { UserId = 4, Message = "Room assignment changed.", IsRead = false, CreatedAt = DateTime.UtcNow },
            //    new Notifications { UserId = 5, Message = "Maintenance request approved.", IsRead = true, CreatedAt = DateTime.UtcNow }
            //};
            //    context.Notifications.AddRange(notifications);
            //    context.SaveChanges();
            //}

            // ==========================
            // 26️⃣ AuditLogs
            //if (!context.AuditLogs.Any())
            //{
            //    var logs = new List<AuditLog>
            //    {
            //        new AuditLog { UserId = 1, Action = "Logged in", CreatedAt = DateTime.UtcNow },
            //        new AuditLog { UserId = 2, Action = "Updated profile", CreatedAt = DateTime.UtcNow },
            //        new AuditLog { UserId = 3, Action = "Added course", CreatedAt = DateTime.UtcNow },
            //        new AuditLog { UserId = 4, Action = "Deleted announcement", CreatedAt = DateTime.UtcNow },
            //        new AuditLog { UserId = 5, Action = "Created project", CreatedAt = DateTime.UtcNow }
            //    };
            //                context.AuditLogs.AddRange(logs);
            //    context.SaveChanges();
            //}

            // ==========================
            // 27️⃣ RoomPaths
            if (!context.RoomPaths.Any())
            {
                var paths = new List<RoomPath>
                {
                    new RoomPath { FromRoomId = 1, ToRoomId = 2, PathDescription = "Go straight, then turn left" },
                    new RoomPath { FromRoomId = 1, ToRoomId = 3, PathDescription = "Go straight, take stairs to 2nd floor" },
                    new RoomPath { FromRoomId = 2, ToRoomId = 4, PathDescription = "Follow corridor and turn right" },
                    new RoomPath { FromRoomId = 3, ToRoomId = 5, PathDescription = "Take elevator to floor 1" },
                    new RoomPath { FromRoomId = 4, ToRoomId = 1, PathDescription = "Reverse path through corridor" }
                };
                context.RoomPaths.AddRange(paths);
                context.SaveChanges();
            }

            // ==========================
            // 28️⃣ EmailVerificationCode
            //if (!context.EmailVerificationCodes.Any())
            //{
            //    var emailCodes = new List<EmailVerificationCode>
            //    {
            //        new EmailVerificationCode { Name="Alice", Email="alice@example.com", PasswordHash="hashedpassword1", Role = UserRole.Student, Code="CODE1", ExpiryDate=DateTime.UtcNow.AddHours(1), IsUsed=false },
            //        new EmailVerificationCode { Name="Bob", Email="bob@example.com", PasswordHash="hashedpassword2", Role = UserRole.Student, Code="CODE2", ExpiryDate=DateTime.UtcNow.AddHours(1), IsUsed=false },
            //        new EmailVerificationCode { Name="Carol", Email="carol@example.com", PasswordHash="hashedpassword3", Role = UserRole.Student, Code="CODE3", ExpiryDate=DateTime.UtcNow.AddHours(1), IsUsed=false },
            //        new EmailVerificationCode { Name="David", Email="david@example.com", PasswordHash="hashedpassword4", Role = UserRole.Student,  Code="CODE4", ExpiryDate=DateTime.UtcNow.AddHours(1), IsUsed=false },
            //        new EmailVerificationCode { Name="Eman", Email="eman@example.com", PasswordHash="hashedpassword5", Role = UserRole.Student, Code="CODE5", ExpiryDate=DateTime.UtcNow.AddHours(1), IsUsed=false }
            //    };
            //    context.EmailVerificationCodes.AddRange(emailCodes);
            //    context.SaveChanges();
            //}   

            // ==========================
            // 29️⃣ RefreshToken
            //if (!context.RefreshTokens.Any())
            //{
            //    var refreshTokens = new List<RefreshToken>
            //    {
            //        new RefreshToken { UserId=1, Token="TOKEN1", ExpiresAt=DateTime.UtcNow.AddDays(7), IsRevoked=false },
            //        new RefreshToken { UserId=2, Token="TOKEN2", ExpiresAt=DateTime.UtcNow.AddDays(7), IsRevoked=false },
            //        new RefreshToken { UserId=3, Token="TOKEN3", ExpiresAt=DateTime.UtcNow.AddDays(7), IsRevoked=false },
            //        new RefreshToken { UserId=4, Token="TOKEN4", ExpiresAt=DateTime.UtcNow.AddDays(7), IsRevoked=false },
            //        new RefreshToken { UserId=5, Token="TOKEN5", ExpiresAt=DateTime.UtcNow.AddDays(7), IsRevoked=false }
            //    };
            //    context.RefreshTokens.AddRange(refreshTokens);
            //    context.SaveChanges();
            //}

            // ==========================
            // 31️⃣ StudentSections
            //if (!context.StudentSections.Any())
            //{
            //    var studentSections = new List<StudentSection>
            //        {
            //            new StudentSection { StudentId=1, SectionId=1 },
            //            new StudentSection { StudentId=2, SectionId=2 },
            //            new StudentSection { StudentId=3, SectionId=3 },
            //            //new StudentSection { StudentId=4, SectionId=4 },
            //            //new StudentSection { StudentId=5, SectionId=5 }
            //        };
            //    context.StudentSections.AddRange(studentSections);
            //    context.SaveChanges();
            //}

            // ==========================
            // 32️⃣ AdminProfiles
            //if (!context.AdminProfiles.Any())
            //{
            //    var admins = new List<AdminProfile>
            //        {
            //            new AdminProfile { UserId=1, DepartmentId=1, CreatedAt=DateTime.UtcNow },
            //            //new AdminProfile { UserId=7, DepartmentId=2, CreatedAt=DateTime.UtcNow },
            //            //new AdminProfile { UserId=8, DepartmentId=3, CreatedAt=DateTime.UtcNow },
            //            //new AdminProfile { UserId=9, DepartmentId=4, CreatedAt=DateTime.UtcNow },
            //            //new AdminProfile { UserId=10, DepartmentId=5, CreatedAt=DateTime.UtcNow }
            //        };
            //    context.AdminProfiles.AddRange(admins);
            //    context.SaveChanges();
            //}

        }
    }
}
