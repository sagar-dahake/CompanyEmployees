using CompanyEmployee.MVC.Models.Dtos.Employee;


namespace CompanyEmployee.MVC.API_Clients.Contracts
{
    public interface IEmployeeApiClient
    {
        Task<List<EmployeeDto>> GetAll(Guid companyId);
    }
}
