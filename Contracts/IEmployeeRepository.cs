using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;



namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges);

        // existing method (companyId + id)
        Task<Employee?> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

        // new convenience method to fetch employee by employeeId only
        Task<Employee?> GetEmployeeByIdAsync(Guid id, bool trackChanges);

        void CreateEmployeeForCompany(Guid companyId, Employee employee);

        void DeleteEmployee(Employee employee);
    }
}
