using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.ServiceContractsMVC;
using Shared.DataTransferObjects;


using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.Service.ImplementationMVC
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveApiClient _apiClient;
        public LeaveService(ILeaveApiClient apiClient) => _apiClient = apiClient;

        public async Task<List<LeaveRecordDto>> GetByEmployee(Guid employeeId) =>
            await _apiClient.GetByEmployee(employeeId);

        public async Task<LeaveRecordDto> Get(Guid employeeId, Guid id) =>
            await _apiClient.Get(employeeId, id);

        public async Task<LeaveRecordDto> Create(Guid employeeId, LeaveRecordForCreationDto dto) =>
            await _apiClient.Create(employeeId, dto);

        public async Task Update(Guid employeeId, Guid id, LeaveRecordForUpdateDto dto) =>
            await _apiClient.Update(employeeId, id, dto);

        public async Task Delete(Guid employeeId, Guid id) =>
            await _apiClient.Delete(employeeId, id);

        // Phase 1 SP
        public async Task<LeaveSummaryDto> GetSummary(Guid employeeId, int year) =>
            await _apiClient.GetSummary(employeeId, year);
    }
}