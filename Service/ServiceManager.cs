using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ServiceContracts;
using Service;
using System;
using System.Collections.Generic;
using System.Text;



namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        // new service lazies
        private readonly Lazy<ISalaryService> _salaryService;
        private readonly Lazy<IPayslipService> _payslipService;
        private readonly Lazy<ILeaveService> _leaveService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));

            _salaryService = new Lazy<ISalaryService>(() => new SalaryService(repositoryManager, logger, mapper));
            _payslipService = new Lazy<IPayslipService>(() => new PayslipService(repositoryManager, logger, mapper));
            _leaveService = new Lazy<ILeaveService>(() => new LeaveService(repositoryManager, logger, mapper));
        }

        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        // new service properties
        public ISalaryService SalaryService => _salaryService.Value;
        public IPayslipService PayslipService => _payslipService.Value;
        public ILeaveService LeaveService => _leaveService.Value;
    }
}