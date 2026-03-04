using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository.Configuration
{
    public class PayslipConfiguration : IEntityTypeConfiguration<Payslip>
    {
        public void Configure(EntityTypeBuilder<Payslip> builder)
        {
            builder.ToTable("Payslips");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.GrossAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TaxAmount).HasColumnType("decimal(18,2)").HasDefaultValue(0m);
            builder.Property(p => p.Deductions).HasColumnType("decimal(18,2)").HasDefaultValue(0m);
            builder.Property(p => p.NetAmount).HasColumnType("decimal(18,2)");

            builder.Property(p => p.PayslipDate).IsRequired();

            builder.HasOne(p => p.Employee)
                   .WithMany(e => e.Payslips)
                   .HasForeignKey(p => p.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Salary)
                   .WithMany()
                   .HasForeignKey(p => p.SalaryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => new { p.EmployeeId, p.PayslipDate });
        }
    }
}