using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Presentation.ModelBinder;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "120SecondsDuration")]

    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service) => _service = service;
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCompanies()
        {
            //throw new Exception("Exception");

            var companies =  await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        [ResponseCache(Duration = 60)]

        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company =  await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyForCreation)
        {
            if (companyForCreation is null)
                return BadRequest("CompanyForCreationDto object is null");
            var createdCompany =await  _service.CompanyService.CreateCompanyAsync(companyForCreation);
            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id },
            createdCompany);
        }

        [HttpGet("collection/{ids}", Name = "CompanyCollection")]
        //public IActionResult GetCompanyCollection([FromRoute] IEnumerable<Guid> ids)----- changed for header tab k location se uthayi link work krnwe k liye

        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)

        {
            var companies =  await _service.CompanyService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(companies);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody]
         IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result =
            await  _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids },
            result.companies);
           // return CreatedAtRoute("CompanyCollection",new { ids = result.ids },
             // result.companies
                   //);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
           await   _service.CompanyService.DeleteCompanyAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            if (company is null)
                return BadRequest("CompanyForUpdateDto object is null");

           await  _service.CompanyService.UpdateCompanyAsync(id, company, trackChanges: true);

            return NoContent();
        }


    }
}
