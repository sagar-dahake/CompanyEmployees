using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record SalaryForCreationDto
    {
        [Required]
        public decimal BaseAmount { get; init; }

        public decimal Allowances { get; init; } = 0m;

        [MaxLength(8)]
        public string? Currency { get; init; } = "USD";

        [Required]
        public DateTime EffectiveFrom { get; init; }

        public DateTime? EffectiveTo { get; init; }
    }

}