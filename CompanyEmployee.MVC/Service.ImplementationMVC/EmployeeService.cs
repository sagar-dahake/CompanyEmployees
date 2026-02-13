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

    }

}

