using System;

namespace Shared.DataTransferObjects
{
    public record SalaryDto
    {
        public Guid Id { get; init; }
        public Guid EmployeeId { get; init; }
        public decimal BaseAmount { get; init; }
        public decimal Allowances { get; init; }
        public string? Currency { get; init; }
        public DateTime EffectiveFrom { get; init; }
        public DateTime? EffectiveTo { get; init; }
    }


}