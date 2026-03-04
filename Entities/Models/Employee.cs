//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text;

//namespace Entities.Models
//{
//    public class Employee
//    {
//        [Column("EmployeeId")]
//        public Guid Id { get; set; }

//        [Required(ErrorMessage = "Employee name is a required field.")]
//        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
//        public string? Name { get; set; }

//        [Required(ErrorMessage = "Age is a required field.")]
//        public int Age { get; set; }

//        [Required(ErrorMessage = "Position is a required field.")]
//        [MaxLength(50, ErrorMessage = "Maximum length for the Position is 50 characters.")] 
//    public string? Position { get; set; }

//        [ForeignKey(nameof(Company))]
//        public Guid CompanyId { get; set; }
//        public Company? Company { get; set; }
//    }
//}




                                      ///////     COPILOT PROVIDED ETENSIONFOR EMPLOYEE MODEL     ///////
                                      ///



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.Collections.Generic;


namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Position is 50 characters.")]
        public string? Position { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }

        // Navigation collections for payroll & leave
        public ICollection<Salary>? Salaries { get; set; }
        public ICollection<Payslip>? Payslips { get; set; }
        public ICollection<LeaveRecord>? LeaveRecords { get; set; }
    }
}