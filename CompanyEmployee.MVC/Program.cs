using CompanyEmployee.MVC.Infrastucture.ServiceExtensions;
using CompanyEmployee.MVC.Service.ImplementationMVC;
using CompanyEmployee.MVC.ServiceContractsMVC;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Load NLog configuration
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));

// Enable NLog as the logging provider (enables ${aspnet-*} layout renderers)
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApiClients(builder.Configuration);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ISalaryService, SalaryService>();
builder.Services.AddScoped<IPayslipService, PayslipService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();


builder.Services.AddSession();

var app = builder.Build();

// Global exception handler — catches ALL unhandled MVC exceptions
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (exceptionFeature != null)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Error(exceptionFeature.Error, "Unhandled MVC exception: {Message}", exceptionFeature.Error.Message);
        }

        context.Response.Redirect("/Home/Error");
    });
});

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");
app.Run();
