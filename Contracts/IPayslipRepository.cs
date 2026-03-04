using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace Contracts
{
    public interface IPayslipRepository
    {
        Task<IEnumerable<Payslip>> GetPayslipsByEmployeeAsync(Guid employeeId, bool trackChanges);
        Task<Payslip?> GetPayslipAsync(Guid employeeId, Guid id, bool trackChanges);
        void CreatePayslip(Payslip payslip);
        void UpdatePayslip(Payslip payslip);
        void DeletePayslip(Payslip payslip);
        Task<Payslip?> GetPayslipForMonthAsync(Guid employeeId, int year, int month, bool trackChanges);
    }
}