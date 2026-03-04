using Shared.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.ServiceContractsMVC
{
    public interface IPayslipService
    {
        Task<List<PayslipDto>> GetByEmployee(Guid employeeId);
        Task<PayslipDto> Get(Guid employeeId, Guid id);
        Task<PayslipDto> Create(Guid employeeId, PayslipForCreationDto dto);
        Task Update(Guid employeeId, Guid id, PayslipForCreationDto dto);
        Task Delete(Guid employeeId, Guid id);
    }
}