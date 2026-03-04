using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Contracts
{
    public interface ILeaveRecordRepository
    {
        Task<IEnumerable<LeaveRecord>> GetLeavesByEmployeeAsync(Guid employeeId, bool trackChanges);
        Task<LeaveRecord?> GetLeaveAsync(Guid employeeId, Guid id, bool trackChanges);
        void CreateLeaveForEmployee(Guid employeeId, LeaveRecord leave);
        void UpdateLeave(LeaveRecord leave);
        void DeleteLeave(LeaveRecord leave);

        Task<int> GetUnpaidLeaveDaysForMonthAsync(Guid employeeId, int year, int month, bool trackChanges);
    }
}