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
    public class LeaveController : ControllerBase
    {
        private readonly IServiceManager _services;

        public LeaveController(IServiceManager services) => _services = services;

        [HttpGet("employee/{employeeId:guid}")]
        public async Task<IActionResult> GetByEmployee(Guid employeeId)
        {
            var list = await _services.LeaveService.GetLeavesForEmployeeAsync(employeeId, trackChanges: false);
            return Ok(list);
        }

        [HttpGet("employee/{employeeId:guid}/{id:guid}", Name = "GetLeave")]
        public async Task<IActionResult> Get(Guid employeeId, Guid id)
        {
            var dto = await _services.LeaveService.GetLeaveAsync(employeeId, id, trackChanges: false);
            if (dto is null) return NotFound();
            return Ok(dto);
        }

        [HttpPost("employee/{employeeId:guid}")]
        public async Task<IActionResult> Create(Guid employeeId, [FromBody] LeaveRecordForCreationDto dto)
        {
            var created = await _services.LeaveService.CreateLeaveForEmployeeAsync(employeeId, dto);
            return CreatedAtRoute("GetLeave", new { employeeId, id = created.Id }, created);
        }

        [HttpPut("employee/{employeeId:guid}/{id:guid}")]
        public async Task<IActionResult> Update(Guid employeeId, Guid id, [FromBody] LeaveRecordForUpdateDto dto)
        {
            await _services.LeaveService.UpdateLeaveForEmployeeAsync(employeeId, id, dto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("employee/{employeeId:guid}/{id:guid}")]
        public async Task<IActionResult> Delete(Guid employeeId, Guid id)
        {
            await _services.LeaveService.DeleteLeaveForEmployeeAsync(employeeId, id, trackChanges: false);
            return NoContent();
        }
    }
}