using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;


using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class LeaveRecordRepository : RepositoryBase<LeaveRecord>, ILeaveRecordRepository
    {
        public LeaveRecordRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<LeaveRecord>> GetLeavesByEmployeeAsync(Guid employeeId, bool trackChanges) =>
            await FindByCondition(l => l.EmployeeId == employeeId, trackChanges)
                  .OrderByDescending(l => l.StartDate)
                  .ToListAsync();

        public async Task<LeaveRecord?> GetLeaveAsync(Guid employeeId, Guid id, bool trackChanges) =>
            await FindByCondition(l => l.EmployeeId == employeeId && l.Id == id, trackChanges)
                  .SingleOrDefaultAsync();

        public void CreateLeaveForEmployee(Guid employeeId, LeaveRecord leave)
        {
            leave.EmployeeId = employeeId;
            Create(leave);
        }

        public void UpdateLeave(LeaveRecord leave) => Update(leave);

        public void DeleteLeave(LeaveRecord leave) => Delete(leave);

        public async Task<int> GetUnpaidLeaveDaysForMonthAsync(Guid employeeId, int year, int month, bool trackChanges)
        {
            var monthStart = new DateTime(year, month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var leaves = await FindByCondition(lr =>
                lr.EmployeeId == employeeId &&
                lr.Type == LeaveType.Unpaid &&
                lr.Status == LeaveStatus.Approved &&
                lr.StartDate <= monthEnd &&
                lr.EndDate >= monthStart,
                trackChanges)
                .ToListAsync();

            // Calculate overlapping days
            int totalDays = 0;
            foreach (var leave in leaves)
            {
                var effectiveStart = leave.StartDate < monthStart ? monthStart : leave.StartDate;
                var effectiveEnd = leave.EndDate > monthEnd ? monthEnd : leave.EndDate;
                totalDays += (effectiveEnd - effectiveStart).Days + 1;
            }

            return totalDays;
        }
    }
}