using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.Models.Dtos.Authentication;


namespace CompanyEmployee.MVC.API_Clients.Implementation
{
    public class AuthApiClient : IAuthApiClient
    {
        private readonly HttpClient _client;

        public AuthApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            var response = await _client.PostAsJsonAsync(
                "authentication/login", dto);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TokenDto>();
        }
    }

}
