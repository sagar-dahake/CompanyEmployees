using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace Shared.DataTransferObjects
{
    [Serializable]
    public record EmployeeDto(Guid Id, string Name, int Age, string Position)
    {
       
    }
}