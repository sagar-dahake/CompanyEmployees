using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployee.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
