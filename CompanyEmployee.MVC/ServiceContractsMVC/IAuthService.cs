using CompanyEmployee.MVC.Models.Dtos.Authentication;




namespace CompanyEmployee.MVC.ServiceContractsMVC
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto loginDto);
    }

}
