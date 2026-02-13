using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CompanyForUpdateDto(string Name, string Address, string Country,
 IEnumerable<EmployeeForCreationDto> Employees);
}