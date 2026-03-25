using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AddErrorLogsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    ErrorLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Level = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceClass = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SourceNamespace = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RequestPath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HttpMethod = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HttpStatusCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.ErrorLogId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_CreatedAt",
                table: "ErrorLogs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ErrorLogs_Level",
                table: "ErrorLogs",
                column: "Level");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");
        }
    }
}
