using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.DataTransferObjects;




namespace ServiceContracts
{
    public interface ILeaveService
    {
        Task<IEnumerable<LeaveRecordDto>> GetLeavesForEmployeeAsync(Guid employeeId, bool trackChanges);
        Task<LeaveRecordDto?> GetLeaveAsync(Guid employeeId, Guid id, bool trackChanges);
        Task<LeaveRecordDto> CreateLeaveForEmployeeAsync(Guid employeeId, LeaveRecordForCreationDto leaveForCreation);
        Task UpdateLeaveForEmployeeAsync(Guid employeeId, Guid id, LeaveRecordForUpdateDto leaveForUpdate, bool trackChanges);
        Task DeleteLeaveForEmployeeAsync(Guid employeeId, Guid id, bool trackChanges);
    }
}
