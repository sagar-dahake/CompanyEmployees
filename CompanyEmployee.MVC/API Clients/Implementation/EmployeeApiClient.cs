using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.Models.Dtos.Employee;

namespace CompanyEmployee.MVC.API_Clients.Implementation
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _client;

        public EmployeeApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<EmployeeDto>> GetAll(Guid companyId)
        {
            var response = await _client.GetAsync($"companies/{companyId}/employees");

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<List<EmployeeDto>>();
        }

    }

}
