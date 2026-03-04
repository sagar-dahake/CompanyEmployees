using System;
using System.Collections.Generic;
using System.Text;


namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }

        // new repository properties
        ISalaryRepository Salary { get; }
        IPayslipRepository Payslip { get; }
        ILeaveRecordRepository Leave { get; }

        Task SaveAsync();
    }
}
