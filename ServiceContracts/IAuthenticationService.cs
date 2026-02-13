using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
