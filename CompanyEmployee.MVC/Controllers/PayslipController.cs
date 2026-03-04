using CompanyEmployee.MVC.ServiceContractsMVC;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.Controllers
{
    public class PayslipController : Controller
    {
        private readonly IPayslipService _service;

        public PayslipController(IPayslipService service) => _service = service;

        public async Task<IActionResult> Index(Guid employeeId)
        {
            var list = await _service.GetByEmployee(employeeId);
            ViewBag.EmployeeId = employeeId;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create(Guid employeeId)
        {
            ViewBag.EmployeeId = employeeId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid employeeId, PayslipForCreationDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _service.Create(employeeId, dto);
            return RedirectToAction("Index", new { employeeId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid employeeId, Guid id)
        {
            await _service.Delete(employeeId, id);
            return RedirectToAction("Index", new { employeeId });
        }

        // Optional: the "eye" button in Index links to Get — keep it simple by redirecting to Index.
        [HttpGet]
        public IActionResult Get(Guid employeeId, Guid id)
        {
            return RedirectToAction("Index", new { employeeId });
        }
    }
}