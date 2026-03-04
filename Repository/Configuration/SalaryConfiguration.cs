using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository.Configuration
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("Salaries");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.BaseAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(s => s.Allowances)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0m);

            builder.Property(s => s.Currency)
                   .HasMaxLength(8);

            builder.Property(s => s.EffectiveFrom)
                   .IsRequired();

            builder.Property(s => s.EffectiveTo)
                   .IsRequired(false);

            builder.HasOne(s => s.Employee)
                   .WithMany(e => e.Salaries)
                   .HasForeignKey(s => s.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
