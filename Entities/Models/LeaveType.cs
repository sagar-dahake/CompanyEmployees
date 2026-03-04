using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Models
{
    public enum LeaveType
    {
        Paid,
        Unpaid,
        Sick,
        Casual,
        Maternity,
        Paternity,
        Other
    }

    public enum LeaveStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled
    }

    public class LeaveRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public LeaveType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // computed days or stored explicitly
        public int Days { get; set; }

        public string? Reason { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReviewedAt { get; set; }
    }
}