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
    public class PayslipController : ControllerBase
    {
        private readonly IServiceManager _services;

        public PayslipController(IServiceManager services) => _services = services;

        [HttpGet("employee/{employeeId:guid}")]
        public async Task<IActionResult> GetByEmployee(Guid employeeId)
        {
            var list = await _services.PayslipService.GetPayslipsForEmployeeAsync(employeeId, trackChanges: false);
            return Ok(list);
        }

        [HttpGet("employee/{employeeId:guid}/{id:guid}", Name = "GetPayslip")]
        public async Task<IActionResult> Get(Guid employeeId, Guid id)
        {
            var dto = await _services.PayslipService.GetPayslipAsync(employeeId, id, trackChanges: false);
            if (dto is null) return NotFound();
            return Ok(dto);
        }

        [HttpPost("employee/{employeeId:guid}")]
        public async Task<IActionResult> Create(Guid employeeId, [FromBody] PayslipForCreationDto dto)
        {
            if (dto is null)
                return BadRequest("PayslipForCreationDto object is null");

            
            var created = await _services.PayslipService.CreatePayslipForEmployeeAsync(employeeId, dto);
            return CreatedAtRoute("GetPayslip", new { employeeId, id = created.Id }, created);
        }

        /// <summary>
        /// Generates a payslip for the specified employee and month automatically
        /// </summary>
        [HttpPost("employee/{employeeId:guid}/generate")]
        public async Task<IActionResult> GenerateForMonth(
            Guid employeeId,
            [FromQuery] int year,
            [FromQuery] int month)
        {
            if (year < 2000 || year > 2100)
                return BadRequest("Invalid year. Must be between 2000 and 2100.");

            if (month < 1 || month > 12)
                return BadRequest("Invalid month. Must be between 1 and 12.");

            try
            {
                var created = await _services.PayslipService.GeneratePayslipForMonthAsync(employeeId, year, month);
                return CreatedAtRoute("GetPayslip", new { employeeId, id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("employee/{employeeId:guid}/{id:guid}")]
        public async Task<IActionResult> Update(Guid employeeId, Guid id, [FromBody] PayslipForCreationDto dto)
        {
            if (dto is null)
                return BadRequest("PayslipForCreationDto object is null");

            await _services.PayslipService.UpdatePayslipForEmployeeAsync(employeeId, id, dto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("employee/{employeeId:guid}/{id:guid}")]
        public async Task<IActionResult> Delete(Guid employeeId, Guid id)
        {
            await _services.PayslipService.DeletePayslipForEmployeeAsync(employeeId, id, trackChanges: false);
            return NoContent();
        }
    }
}