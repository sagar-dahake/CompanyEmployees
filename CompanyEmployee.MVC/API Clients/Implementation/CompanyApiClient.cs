using CompanyEmployee.MVC.API_Clients.Contracts;

using CompanyEmployee.MVC.Models.Dtos.Company;


namespace CompanyEmployee.MVC.API_Clients.Implementation
{
    public class CompanyApiClient : ICompanyApiClient
    {
        private readonly HttpClient _client;

        public CompanyApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var response = await _client.GetAsync("companies");

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<List<CompanyDto>>();
        }
    }
}
