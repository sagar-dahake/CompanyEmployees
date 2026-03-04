using CompanyEmployee.MVC.API_Clients;
using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.Models.Dtos.Employee;
using CompanyEmployee.MVC.ServiceContractsMVC;
using System.ComponentModel.Design;



namespace CompanyEmployee.MVC.Service.ImplementationMVC
{
   

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeApiClient _apiClient;

        public EmployeeService(IEmployeeApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<EmployeeDto>> GetAll(Guid companyId)
        {
            return await _apiClient.GetAll(companyId);
        }


        public async Task<EmployeeDto> Get(Guid companyId, Guid id)
        {
            return await _apiClient.Get(companyId, id);
        }

        public async Task Create(Guid companyId, EmployeeCreateDto employee)
        {
            await _apiClient.Create(companyId, employee);
        }

        public async Task Update(Guid companyId, Guid id, EmployeeUpdateDto employee)
        {
            await _apiClient.Update(companyId, id, employee);
        }

        public async Task Delete(Guid companyId, Guid id)
        {
            await _apiClient.Delete(companyId, id);
        }


    }

}

