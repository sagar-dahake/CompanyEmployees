using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record LeaveRecordForUpdateDto
    {
        [Required]
        public int Type { get; init; }

        [Required]
        public DateTime StartDate { get; init; }

        [Required]
        public DateTime EndDate { get; init; }

        [Required]
        [Range(1, 365)]
        public int Days { get; init; }

        [MaxLength(1000)]
        public string? Reason { get; init; }

        [Required]
        public int Status { get; init; } // 0=Pending, 1=Approved, 2=Rejected, 3=Cancelled
    }
}