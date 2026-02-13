using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using CompanyEmployees.ActionFilters;
namespace Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto
userForRegistration)
        {
            var result = await _serviceManager.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)

            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(user))
                return Unauthorized();
            return Ok(new
            {
                Token = await _serviceManager.AuthenticationService.CreateToken()
            });
        }

    }
}
