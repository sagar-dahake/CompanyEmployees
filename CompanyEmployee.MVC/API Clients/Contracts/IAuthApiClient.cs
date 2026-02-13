using CompanyEmployee.MVC.Models.Dtos.Authentication;



namespace CompanyEmployee.MVC.API_Clients.Contracts
{
    public interface IAuthApiClient
    {
        Task<TokenDto> Login(LoginDto dto);
    }

}
