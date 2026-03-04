using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface ISalaryService
    {
        Task<IEnumerable<SalaryDto>> GetSalariesForEmployeeAsync(Guid employeeId, bool trackChanges);
        Task<SalaryDto?> GetSalaryAsync(Guid employeeId, Guid id, bool trackChanges);
        Task<SalaryDto> CreateSalaryForEmployeeAsync(Guid employeeId, SalaryForCreationDto salaryForCreation);
        Task UpdateSalaryForEmployeeAsync(Guid employeeId, Guid id, SalaryForUpdateDto salaryForUpdate, bool trackChanges);
        Task DeleteSalaryForEmployeeAsync(Guid employeeId, Guid id, bool trackChanges);
    }
}