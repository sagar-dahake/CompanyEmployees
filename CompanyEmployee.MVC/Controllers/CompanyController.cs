using CompanyEmployee.MVC.ServiceContractsMVC;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _service.GetAll();
            return View(companies);
        }
    }

}
