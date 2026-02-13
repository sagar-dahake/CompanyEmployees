using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
                new Company
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "IT_Solutions Ltd",
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                    Country = "USA"
                },
                new Company
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Admin_Solutions Ltd",
                    Address = "312 Forest Avenue, BF 923",
                    Country = "USA"
                },
                new Company
                {
                    Id = new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60"),
                    Name = "Finance_Gurus Inc",
                    Address = "100 Market Street, San Francisco, CA 94105",
                    Country = "USA"
                },
                new Company
                {
                    Id = new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a"),
                    Name = "HealthCare_Plus",
                    Address = "45 Wellness Blvd, Austin, TX 73301",
                    Country = "USA"
                },
                new Company
                {
                    Id = new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab"),
                    Name = "EduTech_Services",
                    Address = "77 Knowledge Park, Boston, MA 02115",
                    Country = "USA"
                }
            );
        }
    }

}
