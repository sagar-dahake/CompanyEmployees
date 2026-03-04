using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.ServiceContractsMVC;
using Shared.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.Service.ImplementationMVC
{
    public class PayslipService : IPayslipService
    {
        private readonly IPayslipApiClient _apiClient;
        public PayslipService(IPayslipApiClient apiClient) => _apiClient = apiClient;

        public async Task<List<PayslipDto>> GetByEmployee(Guid employeeId) =>
            await _apiClient.GetByEmployee(employeeId);

        public async Task<PayslipDto> Get(Guid employeeId, Guid id) =>
            await _apiClient.Get(employeeId, id);

        public async Task<PayslipDto> Create(Guid employeeId, PayslipForCreationDto dto) =>
            await _apiClient.Create(employeeId, dto);

        public async Task Update(Guid employeeId, Guid id, PayslipForCreationDto dto) =>
            await _apiClient.Update(employeeId, id, dto);

        public async Task Delete(Guid employeeId, Guid id) =>
            await _apiClient.Delete(employeeId, id);
    }
}