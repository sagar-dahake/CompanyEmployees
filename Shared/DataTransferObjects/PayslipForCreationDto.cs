using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PayslipForCreationDto
    {
        public Guid? SalaryId { get; init; }

        [Required(ErrorMessage = "Gross amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Gross amount must be positive")]
        public decimal GrossAmount { get; init; }

        public decimal TaxAmount { get; init; } = 0m;

        public decimal Deductions { get; init; } = 0m;

        [Required(ErrorMessage = "Net amount is required")]
        public decimal NetAmount { get; init; }

        [Required(ErrorMessage = "Payslip date is required")]
        public DateTime PayslipDate { get; init; }
    }
}