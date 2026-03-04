using Shared.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.ServiceContractsMVC
{
    public interface ISalaryService
    {
        Task<List<SalaryDto>> GetByEmployee(Guid employeeId);
        Task<SalaryDto> Get(Guid employeeId, Guid id);
        Task<SalaryDto> Create(Guid employeeId, SalaryForCreationDto dto);
        Task Update(Guid employeeId, Guid id, SalaryForUpdateDto dto);
        Task Delete(Guid employeeId, Guid id);
    }
}