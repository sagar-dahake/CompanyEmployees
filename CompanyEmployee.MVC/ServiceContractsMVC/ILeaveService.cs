using Shared.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.ServiceContractsMVC
{
    public interface ILeaveService
    {
        Task<List<LeaveRecordDto>> GetByEmployee(Guid employeeId);
        Task<LeaveRecordDto> Get(Guid employeeId, Guid id);
        Task<LeaveRecordDto> Create(Guid employeeId, LeaveRecordForCreationDto dto);
        Task Update(Guid employeeId, Guid id, LeaveRecordForUpdateDto dto);
        Task Delete(Guid employeeId, Guid id);
    }
}