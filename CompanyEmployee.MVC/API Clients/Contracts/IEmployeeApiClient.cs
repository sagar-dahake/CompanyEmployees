using CompanyEmployee.MVC.Models.Dtos.Employee;


namespace CompanyEmployee.MVC.API_Clients.Contracts
{
    public interface IEmployeeApiClient
    {
        Task<List<EmployeeDto>> GetAll(Guid companyId);
        Task<EmployeeDto> Get(Guid companyId, Guid id);


        Task Create(Guid companyId, EmployeeCreateDto dto);
        Task Update(Guid companyId, Guid id, EmployeeUpdateDto dto);
        Task Delete(Guid companyId, Guid id);

    }
}
