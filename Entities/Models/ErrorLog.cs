using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ErrorLog
    {
        [Column("ErrorLogId")]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(10)]
        public string Level { get; set; } = string.Empty;  // ERROR, WARN, FATAL

        [Required]
        public string Message { get; set; } = string.Empty;

        public string? StackTrace { get; set; }

        [MaxLength(500)]
        public string? SourceClass { get; set; }   // e.g., Service.CompanyService

        [MaxLength(500)]
        public string? SourceNamespace { get; set; } // e.g., Service

        [MaxLength(1000)]
        public string? RequestPath { get; set; }    // e.g., /api/companies/bad-guid

        [MaxLength(10)]
        public string? HttpMethod { get; set; }     // GET, POST, PUT, DELETE

        public int? HttpStatusCode { get; set; }    // 404, 500, etc.
    }
}
