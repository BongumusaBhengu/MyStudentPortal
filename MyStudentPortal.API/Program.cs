using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyStudentPortal.Application.Common.Mappings;
using MyStudentPortal.Application.Features.Students.Queries;
using MyStudentPortal.Application.Features.Students.Queries.Register;
using MyStudentPortal.Application.Features.Users;
using MyStudentPortal.Application.Features.Users.Queries;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Persistence.Contexts;
using MyStudentPortal.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<StudentPortalDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Register IUnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add MediatR services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add MediatR handlers
//User
builder.Services.AddTransient<IRequestHandler<CreateApplicationUserQuery, ApplicationUserDto>, CreateApplicationUserQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetUserApplicationUserByIdQuery, ApplicationUserDto>, GetUserApplicationUserByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateApplicationUserQuery, ApplicationUserDto>, UpdateApplicationUserQueryHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteApplicationUserQuery, bool>, DeleteApplicationUserQueryHandler>();
//Student
builder.Services.AddTransient<IRequestHandler<RegisterStudentQuery, StudetDto>, RegisterStudentQueryHandler>();
builder.Services.AddTransient<IRequestHandler<GetStudentByIdQuery, StudetDto>, GetStudentByIdQueryHandler>();
builder.Services.AddTransient<IRequestHandler<UpdateStudentQuery, StudetDto>, UpdateStudentQueryHandler>();
builder.Services.AddTransient<IRequestHandler<DeleteStudentUserQuery, bool>, DeleteStudentUserQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Portal API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

await app.RunAsync();