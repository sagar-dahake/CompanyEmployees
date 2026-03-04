using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record LeaveSummaryDto
    {
        public Guid EmployeeId { get; init; }
        public int Year { get; init; }
        public int TotalPaidLeaves { get; init; }
        public int TotalUnpaidLeaves { get; init; }
        public int TotalSickLeaves { get; init; }
        public int PendingLeaves { get; init; }
        public int ApprovedLeaves { get; init; }
        public int RejectedLeaves { get; init; }
    }
}
