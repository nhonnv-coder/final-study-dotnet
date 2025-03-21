using FinalMvcNet.Data;
using FinalMvcNet.Models.ViewModels;
using FinalMvcNet.Repositories.Projects;
using FinalMvcNet.Repositories.Sprints;
using FinalMvcNet.Repositories.TestSuites;
using FinalMvcNet.Services.File;
using FinalMvcNet.Services.Projects;
using FinalMvcNet.Services.Sprints;
using FinalMvcNet.Services.TestSuites;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString =
    builder.Configuration.GetConnectionString("defaultConnection")
    ?? throw new InvalidOperationException("Connection string 'defaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder
    .Services.AddDefaultIdentity<IdentityUser>(options =>
        options.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAutoMapper(typeof(Program));

// Services
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ISprintService, SprintService>();
builder.Services.AddTransient<ITestSuiteService, TestSuiteService>();

// Repositories
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<ISprintRepository, SprintRepository>();
builder.Services.AddTransient<ITestSuiteRepository, TestSuiteRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ProjectViewModel>();
builder.Services.AddValidatorsFromAssemblyContaining<SprintViewModel>();
builder.Services.AddValidatorsFromAssemblyContaining<TestSuiteViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        DatabaseSeeder.Seed(context);
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine(ex.Message);
    }
}

app.Run();
