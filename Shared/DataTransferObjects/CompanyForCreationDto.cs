using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CompanyForCreationDto(string Name, string Address, string Country,
    IEnumerable<EmployeeForCreationDto>? Employees);   // creating parent child together
}
