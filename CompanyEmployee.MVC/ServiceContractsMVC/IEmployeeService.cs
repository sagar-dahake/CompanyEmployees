using CompanyEmployee.MVC.Models.Dtos.Employee;


namespace CompanyEmployee.MVC.ServiceContractsMVC
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAll(Guid companyId);
    }
}
