using CompanyEmployee.MVC.Models.Dtos.Employee;
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

        public async Task<IActionResult> Index(
     Guid companyId,
     string? search,
     string? sort,
     string? positionFilter)
        {
            var employees = await _service.GetAll(companyId);

            // SEARCH
            if (!string.IsNullOrWhiteSpace(search))
            {
                employees = employees
                    .Where(e => e.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // FILTER (by Position)
            if (!string.IsNullOrWhiteSpace(positionFilter))
            {
                employees = employees
                    .Where(e => e.Position == positionFilter)
                    .ToList();
            }

            // SORT
            employees = sort switch
            {
                "age_asc" => employees.OrderBy(e => e.Age).ToList(),
                "age_desc" => employees.OrderByDescending(e => e.Age).ToList(),
                _ => employees
            };

            ViewBag.CompanyId = companyId;
            ViewBag.CompanyName = Request.Query["companyName"];

            return View(employees);
        }


        [HttpGet]
        public IActionResult Create(Guid companyId)
        {
            ViewBag.CompanyId = companyId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid companyId,
    EmployeeCreateDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Create(companyId, model);

            return RedirectToAction("Index",
                new { companyId });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid companyId, Guid id)
        {
            var employee = await _service.Get(companyId, id);

            var dto = new EmployeeUpdateDto
            {
                Name = employee.Name,
                Age = employee.Age,
                Position = employee.Position
            };

            ViewBag.CompanyId = companyId;
            ViewBag.EmployeeId = id;

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid companyId,
    Guid id,
    EmployeeUpdateDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.Update(companyId, id, model);

            return RedirectToAction("Index",
                new { companyId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid companyId, Guid id)
        {
            await _service.Delete(companyId, id);

            return RedirectToAction("Index",
                new { companyId });
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid companyId, Guid id)
        {
            var employee = await _service.Get(companyId, id);
            if (employee == null) return NotFound();

            ViewBag.CompanyId = companyId;
            return View(employee);
        }





    }

}
