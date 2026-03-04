namespace CompanyEmployee.MVC.Models.Dtos.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }

        // preserve existing positional ctor to avoid breaking code
        // add company fields used by the Details view  
        ///added for details view as instructed by copilot 
        ///// these fields are optional and may be null if not included in the query
        public Guid CompanyId { get; init; }
        public string? CompanyName { get; init; }

    }

}
