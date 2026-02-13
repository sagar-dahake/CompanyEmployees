using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public sealed class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException() : base("Parameter ids is null")
        {
        }
    }
}
