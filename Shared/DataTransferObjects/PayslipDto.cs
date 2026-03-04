using System;

namespace Shared.DataTransferObjects
{
    public record PayslipDto
    {
        public Guid Id { get; init; }
        public Guid EmployeeId { get; init; }
        public Guid? SalaryId { get; init; }
        public decimal GrossAmount { get; init; }
        public decimal TaxAmount { get; init; }
        public decimal Deductions { get; init; }
        public decimal NetAmount { get; init; }
        public DateTime PayslipDate { get; init; }
        public int Month => PayslipDate.Month;
        public int Year => PayslipDate.Year;
    }

}