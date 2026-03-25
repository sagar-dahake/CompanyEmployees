using CompanyEmployee.MVC.ServiceContractsMVC;
using Microsoft.AspNetCore.Mvc;
using CompanyEmployee.MVC.Models.Dtos.Authentication;


namespace CompanyEmployee.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var result = await _service.Login(dto);

                HttpContext.Session.SetString("JWToken", result.Token);
                HttpContext.Session.SetString("UserName", dto.UserName);

                return RedirectToAction("Index", "Company");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(dto);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");
            HttpContext.Session.Remove("UserName");

            return RedirectToAction("Login", "Auth");
        }
    }
}
