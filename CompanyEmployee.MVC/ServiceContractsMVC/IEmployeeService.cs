using CompanyEmployee.MVC.Models.Dtos.Employee;


namespace CompanyEmployee.MVC.ServiceContractsMVC
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAll(Guid companyId);

        Task<EmployeeDto> Get(Guid companyId, Guid id);

        Task Create(Guid companyId, EmployeeCreateDto employee);

        Task Update(Guid companyId, Guid id, EmployeeUpdateDto employee);

        Task Delete(Guid companyId, Guid id);
    }

}
