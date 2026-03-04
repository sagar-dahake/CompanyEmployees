using System;
using System.Collections.Generic;
using System.Text;



namespace ServiceContracts
{
    public interface IServiceManager
    {
        ICompanyService CompanyService { get; }
        IEmployeeService EmployeeService { get; }
        IAuthenticationService AuthenticationService { get; }

        // new services
        ISalaryService SalaryService { get; }
        IPayslipService PayslipService { get; }
        ILeaveService LeaveService { get; }
    }
}
