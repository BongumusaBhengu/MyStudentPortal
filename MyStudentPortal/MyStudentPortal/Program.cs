using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStudentPortal.Application.Common.Mappings;
using MyStudentPortal.Application.Features.Users.Queries;
using MyStudentPortal.Application.Repositories.Interfaces;
using MyStudentPortal.Components;
using MyStudentPortal.Components.Account;
using MyStudentPortal.Domain.Entities;
using MyStudentPortal.Persistence.Contexts;
using MyStudentPortal.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddDbContext<StudentPortalDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StudentPortalDBContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

// Register IUnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//MediatR services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//// Add MediatR handlers
////User
builder.Services.AddTransient<IRequestHandler<CreateApplicationUserQuery, ApplicationUser>, CreateApplicationUserQueryHandler>();
//builder.Services.AddTransient<IRequestHandler<GetUserApplicationUserByIdQuery, ApplicationUserDto>, GetUserApplicationUserByIdQueryHandler>();
//builder.Services.AddTransient<IRequestHandler<UpdateApplicationUserQuery, ApplicationUserDto>, UpdateApplicationUserQueryHandler>();
//builder.Services.AddTransient<IRequestHandler<DeleteApplicationUserQuery, bool>, DeleteApplicationUserQueryHandler>();
////ApplicationUser
//builder.Services.AddTransient<IRequestHandler<RegisterStudentQuery, StudentDto>, RegisterStudentQueryHandler>();
//builder.Services.AddTransient<IRequestHandler<GetStudentByIdQuery, StudentDto>, GetStudentByIdQueryHandler>();
//builder.Services.AddTransient<IRequestHandler<UpdateStudentQuery, StudentDto>, UpdateStudentQueryHandler>();
//builder.Services.AddTransient<IRequestHandler<DeleteStudentUserQuery, bool>, DeleteStudentUserQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MyStudentPortal.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();



await app.RunAsync();
