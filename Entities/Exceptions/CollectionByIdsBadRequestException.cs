using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public sealed class CollectionByIdsBadRequestException : BadRequestException
    {
        public CollectionByIdsBadRequestException() : base("Collection count mismatch comparing to ids.")
        {

        }
    }
}
