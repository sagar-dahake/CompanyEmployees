using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.Models.Dtos.Authentication;
using CompanyEmployee.MVC.ServiceContractsMVC;



namespace CompanyEmployee.MVC.Service.ImplementationMVC
{
    public class AuthService : IAuthService
    {
        private readonly IAuthApiClient _apiClient;

        public AuthService(IAuthApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            return await _apiClient.Login(loginDto);
        }

    }
}
