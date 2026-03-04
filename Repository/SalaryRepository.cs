using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class SalaryRepository : RepositoryBase<Salary>, ISalaryRepository
    {
        public SalaryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Salary>> GetSalariesByEmployeeAsync(Guid employeeId, bool trackChanges) =>
            await FindByCondition(s => s.EmployeeId == employeeId, trackChanges)
                  .OrderByDescending(s => s.EffectiveFrom)
                  .ToListAsync();

        public async Task<Salary?> GetSalaryAsync(Guid employeeId, Guid id, bool trackChanges) =>
            await FindByCondition(s => s.EmployeeId == employeeId && s.Id == id, trackChanges)
                  .SingleOrDefaultAsync();

        public void CreateSalaryForEmployee(Guid employeeId, Salary salary)
        {
            salary.EmployeeId = employeeId;
            Create(salary);
        }

        public void UpdateSalary(Salary salary) => Update(salary);

        public void DeleteSalary(Salary salary) => Delete(salary);

        public async Task<Salary?> GetActiveSalaryAsync(Guid employeeId, DateTime targetDate, bool trackChanges)
        {
            return await FindByCondition(s =>
                s.EmployeeId == employeeId &&
                s.EffectiveFrom <= targetDate &&
                (s.EffectiveTo == null || s.EffectiveTo >= targetDate),
                trackChanges)
                .OrderByDescending(s => s.EffectiveFrom)
                .FirstOrDefaultAsync();
        }
    }
}