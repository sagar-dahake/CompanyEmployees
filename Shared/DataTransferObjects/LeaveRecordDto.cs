using System;

namespace Shared.DataTransferObjects
{
    public record LeaveRecordDto
    {
        public Guid Id { get; init; }
        public Guid EmployeeId { get; init; }
        public int Type { get; init; }
        public string TypeName { get; init; } = string.Empty; // e.g., "Paid", "Unpaid"
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public int Days { get; init; }
        public string? Reason { get; init; }
        public int Status { get; init; }
        public string StatusName { get; init; } = string.Empty; // e.g., "Pending", "Approved"
        public DateTime AppliedAt { get; init; }
        public DateTime? ReviewedAt { get; init; }
    }
}