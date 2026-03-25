using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            builder.ToTable("ErrorLogs");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.Message)
                   .IsRequired();

            builder.HasIndex(e => e.CreatedAt)
                   .HasDatabaseName("IX_ErrorLogs_CreatedAt");

            builder.HasIndex(e => e.Level)
                   .HasDatabaseName("IX_ErrorLogs_Level");
        }
    }
}
