using CompanyEmployee.MVC.Models.Dtos.Company;


namespace CompanyEmployee.MVC.ServiceContractsMVC
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAll();
    }
}
