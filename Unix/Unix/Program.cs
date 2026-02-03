using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Unix.Data;
using Unix.Data.Modules.Auth.Handler;
using Unix.Data.Services.Implementations.Repository.Auth;
using Unix.Data.Services.Implementations.Services.Academic;
using Unix.Data.Services.Implementations.Services.Auth;
using Unix.Data.Services.Implementations.Services.Campus;
using Unix.Data.Services.Implementations.Services.Content;
using Unix.Data.Services.Implementations.Services.Dashboard;
using Unix.Data.Services.Implementations.Services.Logs;
using Unix.Data.Services.Interfaces.IRepository.Auth;
using Unix.Data.Services.Interfaces.IServices.Academic;
using Unix.Data.Services.Interfaces.IServices.Auth;
using Unix.Data.Services.Interfaces.IServices.Campus;
using Unix.Data.Services.Interfaces.IServices.Content;
using Unix.Data.Services.Interfaces.IServices.Dashboard;
using Unix.Data.Services.Interfaces.IServices.Logs;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// 2️⃣ Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailVerificationRepository, EmailVerificationRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();




// 3️⃣ Services
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<ICourseAssignmentService, CourseAssignmentService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IInstructorCourseService, InstructorCourseService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IStageDriverService, StageDriverService>();
builder.Services.AddScoped<ICampusService, CampusService>();
builder.Services.AddScoped<ICampusNavigationService, CampusNavigationService>();
builder.Services.AddScoped<IContentLostAndFoundService, ContentLostAndFoundService>();
builder.Services.AddScoped<INotificationsService, NotificationsService>();
builder.Services.AddScoped<IAnnouncementsService, AnnouncementsService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();





//4️⃣ MediatR Handlers
builder.Services.AddMediatR(typeof(RegisterCommandHandler).Assembly);

// 5️⃣ Controllers & Swagger
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Unix", Version = "v1" });
});

// 6️⃣ JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        RoleClaimType = "Role"
    };
});

// 0️⃣ Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173",
                        "https://appsales-one.vercel.app") // <-- your React dev server
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();



// 7️⃣ Middleware
if (app.Environment.IsDevelopment() || true)
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unix V1");
        c.RoutePrefix = string.Empty; // Open swagger at root: https://localhost:5001/
    });
}

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var context = services.GetRequiredService<AppSalesDbContext>();

//        context.Database.Migrate();

//        Console.WriteLine("Database Migration applied successfully.");
//    }
//    catch (Exception ex)
//    {
//        // تسجيل الخطأ في حال فشل الاتصال بالقاعدة أثناء الـ Startup
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while migrating the database.");
//    }
//}

//app.UseHttpsRedirection();

app.UseCors("AllowFrontend");


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// Seed database safely
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();  // Apply migrations
    DbSeeder.Seed(db);      // Seed initial data
}



app.Run();
