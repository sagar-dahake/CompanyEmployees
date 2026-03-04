using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace Contracts
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetSalariesByEmployeeAsync(Guid employeeId, bool trackChanges);
        Task<Salary?> GetSalaryAsync(Guid employeeId, Guid id, bool trackChanges);
        void CreateSalaryForEmployee(Guid employeeId, Salary salary);
        void UpdateSalary(Salary salary);
        void DeleteSalary(Salary salary);
        Task<Salary?> GetActiveSalaryAsync(Guid employeeId, DateTime targetDate, bool trackChanges);
    }
}
