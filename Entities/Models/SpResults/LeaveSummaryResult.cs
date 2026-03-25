namespace Entities.Models.SpResults
{
    public class LeaveSummaryResult
    {
        public Guid EmployeeId { get; set; }
        public int Year { get; set; }
        public int TotalPaidLeaves { get; set; }
        public int TotalUnpaidLeaves { get; set; }
        public int TotalSickLeaves { get; set; }
        public int PendingLeaves { get; set; }
        public int ApprovedLeaves { get; set; }
        public int RejectedLeaves { get; set; }
    }
}