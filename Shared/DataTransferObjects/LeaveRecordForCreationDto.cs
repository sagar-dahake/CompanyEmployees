using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record LeaveRecordForCreationDto
    {
        [Required(ErrorMessage = "Leave type is required")]
        public int Type { get; init; } // Maps to LeaveType enum (0=Paid, 1=Unpaid, etc.)

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; init; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; init; }

        [Required(ErrorMessage = "Number of days is required")]
        [Range(1, 365, ErrorMessage = "Days must be between 1 and 365")]
        public int Days { get; init; }

        [MaxLength(1000, ErrorMessage = "Reason cannot exceed 1000 characters")]
        public string? Reason { get; init; }

        public int Status { get; init; } = 0; // Default: Pending
    }
}