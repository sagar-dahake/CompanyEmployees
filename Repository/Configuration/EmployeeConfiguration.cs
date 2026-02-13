using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
            (
                // IT_Solutions Ltd
                new Employee
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Sam Raiden",
                    Age = 26,
                    Position = "Software Developer",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Employee
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "Jana McLeaf",
                    Age = 30,
                    Position = "Software Developer",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Employee
                {
                    Id = new Guid("f6b5a4c3-d2e1-4f09-8a76-112233445566"),
                    Name = "Arjun Patel",
                    Age = 28,
                    Position = "Backend Developer",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Employee
                {
                    Id = new Guid("aa11bb22-cc33-44dd-88ee-9900aabbccdd"),
                    Name = "Neha Sharma",
                    Age = 27,
                    Position = "Frontend Developer",
                    CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },

                // Admin_Solutions Ltd
                new Employee
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Kane Miller",
                    Age = 35,
                    Position = "Administrator",
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                new Employee
                {
                    Id = new Guid("bbccdde1-2233-4455-6677-8899aabbccdd"),
                    Name = "Sophia Turner",
                    Age = 32,
                    Position = "System Admin",
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                new Employee
                {
                    Id = new Guid("ccddeeff-0011-2233-4455-66778899aabb"),
                    Name = "Daniel Brooks",
                    Age = 29,
                    Position = "HR Executive",
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                new Employee
                {
                    Id = new Guid("11223344-5566-7788-99aa-bbccddeeff00"),
                    Name = "Emily Watson",
                    Age = 31,
                    Position = "Office Manager",
                    CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },

                // Finance_Gurus Inc
                new Employee
                {
                    Id = new Guid("22334455-6677-8899-aabb-ccddeeff0011"),
                    Name = "Michael Scott",
                    Age = 40,
                    Position = "Finance Manager",
                    CompanyId = new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60")
                },
                new Employee
                {
                    Id = new Guid("33445566-7788-99aa-bbcc-ddeeff001122"),
                    Name = "Rachel Green",
                    Age = 34,
                    Position = "Accountant",
                    CompanyId = new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60")
                },
                new Employee
                {
                    Id = new Guid("44556677-8899-aabb-ccdd-eeff00112233"),
                    Name = "Kevin Malone",
                    Age = 38,
                    Position = "Senior Accountant",
                    CompanyId = new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60")
                },
                new Employee
                {
                    Id = new Guid("55667788-99aa-bbcc-ddee-ff0011223344"),
                    Name = "Angela Martin",
                    Age = 36,
                    Position = "Finance Controller",
                    CompanyId = new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60")
                },

                // HealthCare_Plus
                new Employee
                {
                    Id = new Guid("66778899-aabb-ccdd-eeff-001122334455"),
                    Name = "Dr. Olivia Brown",
                    Age = 42,
                    Position = "Medical Consultant",
                    CompanyId = new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a")
                },
                new Employee
                {
                    Id = new Guid("778899aa-bbcc-ddee-ff00-112233445566"),
                    Name = "Ethan Clark",
                    Age = 37,
                    Position = "Healthcare Analyst",
                    CompanyId = new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a")
                },
                new Employee
                {
                    Id = new Guid("8899aabb-ccdd-eeff-0011-223344556677"),
                    Name = "Ava Johnson",
                    Age = 29,
                    Position = "Clinical Coordinator",
                    CompanyId = new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a")
                },
                new Employee
                {
                    Id = new Guid("99aabbcc-ddee-ff00-1122-334455667788"),
                    Name = "Liam Wilson",
                    Age = 33,
                    Position = "Operations Manager",
                    CompanyId = new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a")
                },

                // EduTech_Services
                new Employee
                {
                    Id = new Guid("aabbccdd-eeff-0011-2233-445566778899"),
                    Name = "Priya Verma",
                    Age = 27,
                    Position = "Instructional Designer",
                    CompanyId = new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab")
                },
                new Employee
                {
                    Id = new Guid("bbccdde0-1122-3344-5566-778899aabbcc"),
                    Name = "Rohit Mehta",
                    Age = 31,
                    Position = "Content Strategist",
                    CompanyId = new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab")
                },
                new Employee
                {
                    Id = new Guid("ccddee11-2233-4455-6677-8899aabbcc00"),
                    Name = "Sarah Collins",
                    Age = 35,
                    Position = "Product Owner",
                    CompanyId = new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab")
                },
                new Employee
                {
                    Id = new Guid("ddeeff22-3344-5566-7788-99aabbccdd11"),
                    Name = "Noah Anderson",
                    Age = 29,
                    Position = "EdTech Developer",
                    CompanyId = new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab")
                }
            );
        }
    }

}
