namespace CompanyEmployee.MVC.Models.Dtos.Authentication
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
