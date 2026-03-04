using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class PayslipRepository : RepositoryBase<Payslip>, IPayslipRepository
    {
        public PayslipRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Payslip>> GetPayslipsByEmployeeAsync(Guid employeeId, bool trackChanges) =>
            await FindByCondition(p => p.EmployeeId == employeeId, trackChanges)
                  .OrderByDescending(p => p.PayslipDate)
                  .ToListAsync();

        public async Task<Payslip?> GetPayslipAsync(Guid employeeId, Guid id, bool trackChanges) =>
            await FindByCondition(p => p.EmployeeId == employeeId && p.Id == id, trackChanges)
                  .SingleOrDefaultAsync();

        public void CreatePayslip(Payslip payslip) => Create(payslip);

        public void UpdatePayslip(Payslip payslip) => Update(payslip);

        public void DeletePayslip(Payslip payslip) => Delete(payslip);

        public async Task<Payslip?> GetPayslipForMonthAsync(Guid employeeId, int year, int month, bool trackChanges)
        {
            return await FindByCondition(p =>
                p.EmployeeId == employeeId &&
                p.PayslipDate.Year == year &&
                p.PayslipDate.Month == month,
                trackChanges)
                .FirstOrDefaultAsync();
        }
    }
}
