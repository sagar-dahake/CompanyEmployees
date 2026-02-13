using CompanyEmployee.MVC.ServiceContractsMVC;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(Guid companyId, string companyName)
        {
            ViewBag.CompanyName = companyName;

            var employees = await _service.GetAll(companyId);

            return View(employees);
        }



    }

}
