using CompanyEmployee.MVC.Models.Dtos.Employee;

namespace CompanyEmployee.MVC.Models.Dtos.Company
{
    public class CompanyForCreationDtoMVC
    {
        string Name;
        string Address;
        string Country;
        IEnumerable<EmployeeCreateDto>? Employees;
    }
}

