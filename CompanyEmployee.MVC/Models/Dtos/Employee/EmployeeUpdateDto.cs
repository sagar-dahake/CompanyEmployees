namespace CompanyEmployee.MVC.Models.Dtos.Employee
{
    public class EmployeeUpdateDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }
    }

}
