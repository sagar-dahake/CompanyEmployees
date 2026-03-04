using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;



namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly IServiceManager _services;

        public SalaryController(IServiceManager services) => _services = services;

        [HttpGet("employee/{employeeId:guid}")]
        public async Task<IActionResult> GetByEmployee(Guid employeeId)
        {
            var list = await _services.SalaryService.GetSalariesForEmployeeAsync(employeeId, trackChanges: false);
            return Ok(list);
        }

        [HttpGet("employee/{employeeId:guid}/{id:guid}", Name = "GetSalary")]
        public async Task<IActionResult> Get(Guid employeeId, Guid id)
        {
            var dto = await _services.SalaryService.GetSalaryAsync(employeeId, id, trackChanges: false);
            if (dto is null) return NotFound();
            return Ok(dto);
        }

        [HttpPost("employee/{employeeId:guid}")]
        public async Task<IActionResult> Create(Guid employeeId, [FromBody] SalaryForCreationDto dto)
        {
            var created = await _services.SalaryService.CreateSalaryForEmployeeAsync(employeeId, dto);
            return CreatedAtRoute("GetSalary", new { employeeId, id = created.Id }, created);
        }

        [HttpPut("employee/{employeeId:guid}/{id:guid}")]
        public async Task<IActionResult> Update(Guid employeeId, Guid id, [FromBody] SalaryForUpdateDto dto)
        {
            await _services.SalaryService.UpdateSalaryForEmployeeAsync(employeeId, id, dto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("employee/{employeeId:guid}/{id:guid}")]
        public async Task<IActionResult> Delete(Guid employeeId, Guid id)
        {
            await _services.SalaryService.DeleteSalaryForEmployeeAsync(employeeId, id, trackChanges: false);
            return NoContent();
        }
    }
}