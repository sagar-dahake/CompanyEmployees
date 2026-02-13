using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    [Serializable]
    //public record CompanyDto(Guid Id, string Name, string FullAddress)
    //{
    //}

    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? FullAddress { get; init; }
    }
}
