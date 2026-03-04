using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository.Configuration
{
    public class LeaveRecordConfiguration : IEntityTypeConfiguration<LeaveRecord>
    {
        public void Configure(EntityTypeBuilder<LeaveRecord> builder)
        {
            builder.ToTable("LeaveRecords");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Reason).HasMaxLength(1000);
            builder.Property(l => l.Days).IsRequired();

            builder.Property(l => l.StartDate).IsRequired();
            builder.Property(l => l.EndDate).IsRequired();

            builder.HasOne(l => l.Employee)
                   .WithMany(e => e.LeaveRecords)
                   .HasForeignKey(l => l.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(l => new { l.EmployeeId, l.StartDate, l.EndDate });
        }
    }
}