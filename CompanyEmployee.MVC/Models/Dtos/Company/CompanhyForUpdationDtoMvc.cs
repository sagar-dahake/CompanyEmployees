using CompanyEmployee.MVC.Models.Dtos.Employee;


namespace CompanyEmployee.MVC.Models.Dtos.Company
{
    public class CompanhyForUpdationDtoMvc
    {
        string Name; 
        string Address;
        string Country;
        IEnumerable<EmployeeUpdateDto>? Employees;
    }
}
