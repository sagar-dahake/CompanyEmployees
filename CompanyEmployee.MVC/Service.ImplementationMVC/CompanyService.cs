using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.ServiceContractsMVC;
using CompanyEmployee.MVC.Models.Dtos.Company;

namespace CompanyEmployee.MVC.Service.ImplementationMVC
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyApiClient _apiClient;

        public CompanyService(ICompanyApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            return await _apiClient.GetAll();
        }
    }

}
