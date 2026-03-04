//using CompanyEmployee.MVC.API_Clients.Contracts;
//using CompanyEmployee.MVC.API_Clients.Implementation;
//using CompanyEmployee.MVC.Infrastucture.Handler;

//namespace CompanyEmployee.MVC.Infrastucture.ServiceExtensions
//{
//    public static class ServiceExtensions
//    {
//        public static void ConfigureApiClients(
//            this IServiceCollection services,
//            IConfiguration config)
//        {
//            services.AddHttpContextAccessor();

//            services.AddTransient<JwtHandler>();

//            services.AddHttpClient<IEmployeeApiClient, EmployeeApiClient>(c =>
//            {
//                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
//            }).AddHttpMessageHandler<JwtHandler>();

//            services.AddHttpClient<IAuthApiClient, AuthApiClient>(c =>
//            {
//                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
//            });

//            services.AddHttpClient<ICompanyApiClient, CompanyApiClient>(c =>
//            {
//                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
//            })
//                    .AddHttpMessageHandler<JwtHandler>();

//        }
//    }
//}



using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.API_Clients.Implementation;
using CompanyEmployee.MVC.Infrastucture.Handler;



namespace CompanyEmployee.MVC.Infrastucture.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureApiClients(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddHttpContextAccessor();

            services.AddTransient<JwtHandler>();

            services.AddHttpClient<IEmployeeApiClient, EmployeeApiClient>(c =>
            {
                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
            }).AddHttpMessageHandler<JwtHandler>();

            services.AddHttpClient<IAuthApiClient, AuthApiClient>(c =>
            {
                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
            });

            services.AddHttpClient<ICompanyApiClient, CompanyApiClient>(c =>
            {
                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
            })
                    .AddHttpMessageHandler<JwtHandler>();

            // Added clients for payroll & leave APIs
            services.AddHttpClient<ISalaryApiClient, SalaryApiClient>(c =>
            {
                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
            }).AddHttpMessageHandler<JwtHandler>();

            services.AddHttpClient<IPayslipApiClient, PayslipApiClient>(c =>
            {
                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
            }).AddHttpMessageHandler<JwtHandler>();

            services.AddHttpClient<ILeaveApiClient, LeaveApiClient>(c =>
            {
                c.BaseAddress = new Uri(config["ApiSettings:BaseUrl"]);
            }).AddHttpMessageHandler<JwtHandler>();
        }
    }
}




