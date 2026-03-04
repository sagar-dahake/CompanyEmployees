using System;
using System.Collections.Generic;
using System.Text;



namespace Entities.Models
{
    public class Salary
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        // monetary values - use decimal for currency
        public decimal BaseAmount { get; set; }
        public decimal Allowances { get; set; } = 0m;

        public string? Currency { get; set; } = "USD";

        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}