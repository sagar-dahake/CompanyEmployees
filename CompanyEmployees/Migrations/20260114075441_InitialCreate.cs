using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "312 Forest Avenue, BF 923", "USA", "Admin_Solutions Ltd" },
                    { new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60"), "100 Market Street, San Francisco, CA 94105", "USA", "Finance_Gurus Inc" },
                    { new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a"), "45 Wellness Blvd, Austin, TX 73301", "USA", "HealthCare_Plus" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "583 Wall Dr. Gwynn Oak, MD 21207", "USA", "IT_Solutions Ltd" },
                    { new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab"), "77 Knowledge Park, Boston, MA 02115", "USA", "EduTech_Services" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), 35, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Kane Miller", "Administrator" },
                    { new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 31, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Emily Watson", "Office Manager" },
                    { new Guid("22334455-6677-8899-aabb-ccddeeff0011"), 40, new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60"), "Michael Scott", "Finance Manager" },
                    { new Guid("33445566-7788-99aa-bbcc-ddeeff001122"), 34, new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60"), "Rachel Green", "Accountant" },
                    { new Guid("44556677-8899-aabb-ccdd-eeff00112233"), 38, new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60"), "Kevin Malone", "Senior Accountant" },
                    { new Guid("55667788-99aa-bbcc-ddee-ff0011223344"), 36, new Guid("4a5f6d77-7a2e-4d3b-9e9f-1c2d3e4f5a60"), "Angela Martin", "Finance Controller" },
                    { new Guid("66778899-aabb-ccdd-eeff-001122334455"), 42, new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a"), "Dr. Olivia Brown", "Medical Consultant" },
                    { new Guid("778899aa-bbcc-ddee-ff00-112233445566"), 37, new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a"), "Ethan Clark", "Healthcare Analyst" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), 26, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Sam Raiden", "Software Developer" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), 30, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Jana McLeaf", "Software Developer" },
                    { new Guid("8899aabb-ccdd-eeff-0011-223344556677"), 29, new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a"), "Ava Johnson", "Clinical Coordinator" },
                    { new Guid("99aabbcc-ddee-ff00-1122-334455667788"), 33, new Guid("8b2c1a90-6e3d-4c12-9a8b-7f6e5d4c3b2a"), "Liam Wilson", "Operations Manager" },
                    { new Guid("aa11bb22-cc33-44dd-88ee-9900aabbccdd"), 27, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Neha Sharma", "Frontend Developer" },
                    { new Guid("aabbccdd-eeff-0011-2233-445566778899"), 27, new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab"), "Priya Verma", "Instructional Designer" },
                    { new Guid("bbccdde0-1122-3344-5566-778899aabbcc"), 31, new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab"), "Rohit Mehta", "Content Strategist" },
                    { new Guid("bbccdde1-2233-4455-6677-8899aabbccdd"), 32, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Sophia Turner", "System Admin" },
                    { new Guid("ccddee11-2233-4455-6677-8899aabbcc00"), 35, new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab"), "Sarah Collins", "Product Owner" },
                    { new Guid("ccddeeff-0011-2233-4455-66778899aabb"), 29, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Daniel Brooks", "HR Executive" },
                    { new Guid("ddeeff22-3344-5566-7788-99aabbccdd11"), 29, new Guid("f1e2d3c4-b5a6-4789-9abc-1234567890ab"), "Noah Anderson", "EdTech Developer" },
                    { new Guid("f6b5a4c3-d2e1-4f09-8a76-112233445566"), 28, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Arjun Patel", "Backend Developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
