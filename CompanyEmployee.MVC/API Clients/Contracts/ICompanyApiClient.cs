using CompanyEmployee.MVC.Models.Dtos.Company;


namespace CompanyEmployee.MVC.API_Clients.Contracts
{
    public interface ICompanyApiClient
    {
        Task<List<CompanyDto>> GetAll();
    }
}
