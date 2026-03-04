using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.ServiceContractsMVC;
using Shared.DataTransferObjects;


using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.Service.ImplementationMVC
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryApiClient _apiClient;
        public SalaryService(ISalaryApiClient apiClient) => _apiClient = apiClient;

        public async Task<List<SalaryDto>> GetByEmployee(Guid employeeId) =>
            await _apiClient.GetByEmployee(employeeId);

        public async Task<SalaryDto> Get(Guid employeeId, Guid id) =>
            await _apiClient.Get(employeeId, id);

        public async Task<SalaryDto> Create(Guid employeeId, SalaryForCreationDto dto) =>
            await _apiClient.Create(employeeId, dto);

        public async Task Update(Guid employeeId, Guid id, SalaryForUpdateDto dto) =>
            await _apiClient.Update(employeeId, id, dto);

        public async Task Delete(Guid employeeId, Guid id) =>
            await _apiClient.Delete(employeeId, id);
    }
}