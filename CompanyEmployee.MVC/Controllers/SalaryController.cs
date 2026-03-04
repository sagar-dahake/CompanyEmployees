using CompanyEmployee.MVC.ServiceContractsMVC;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

using System;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalaryService _service;

        public SalaryController(ISalaryService service) => _service = service;

        public async Task<IActionResult> Index(Guid employeeId)
        {
            var salaries = await _service.GetByEmployee(employeeId);
            ViewBag.EmployeeId = employeeId;
            return View(salaries);
        }

        [HttpGet]
        public IActionResult Create(Guid employeeId)
        {
            ViewBag.EmployeeId = employeeId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid employeeId, SalaryForCreationDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var created = await _service.Create(employeeId, dto);
            return RedirectToAction("Index", new { employeeId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid employeeId, Guid id)
        {
            var salary = await _service.Get(employeeId, id);
            ViewBag.EmployeeId = employeeId;
            return View(salary);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid employeeId, Guid id, SalaryForUpdateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.Update(employeeId, id, dto);
            return RedirectToAction("Index", new { employeeId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid employeeId, Guid id)
        {
            await _service.Delete(employeeId, id);
            return RedirectToAction("Index", new { employeeId });
        }
    }
}