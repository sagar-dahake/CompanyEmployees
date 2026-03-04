using System;
using System.Collections.Generic;
using System.Text;



namespace Entities.Models
{
    public class Payslip
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public Guid? SalaryId { get; set; }
        public Salary? Salary { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal TaxAmount { get; set; } = 0m;
        public decimal Deductions { get; set; } = 0m;
        public decimal NetAmount { get; set; }

        public DateTime PayslipDate { get; set; } = DateTime.UtcNow;
    }
}
