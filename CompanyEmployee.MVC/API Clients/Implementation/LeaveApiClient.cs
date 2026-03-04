using CompanyEmployee.MVC.API_Clients.Contracts;
using Shared.DataTransferObjects;


using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.API_Clients.Implementation
{
    public class LeaveApiClient : ILeaveApiClient
    {
        private readonly HttpClient _client;
        public LeaveApiClient(HttpClient client) => _client = client;

        public async Task<List<LeaveRecordDto>> GetByEmployee(Guid employeeId)
        {
            var resp = await _client.GetAsync($"leave/employee/{employeeId}");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<List<LeaveRecordDto>>();
        }

        public async Task<LeaveRecordDto> Get(Guid employeeId, Guid id)
        {
            var resp = await _client.GetAsync($"leave/employee/{employeeId}/{id}");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<LeaveRecordDto>();
        }

        public async Task<LeaveRecordDto> Create(Guid employeeId, LeaveRecordForCreationDto dto)
        {
            var resp = await _client.PostAsJsonAsync($"leave/employee/{employeeId}", dto);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<LeaveRecordDto>();
        }

        public async Task Update(Guid employeeId, Guid id, LeaveRecordForUpdateDto dto)
        {
            var resp = await _client.PutAsJsonAsync($"leave/employee/{employeeId}/{id}", dto);
            resp.EnsureSuccessStatusCode();
        }

        public async Task Delete(Guid employeeId, Guid id)
        {
            var resp = await _client.DeleteAsync($"leave/employee/{employeeId}/{id}");
            resp.EnsureSuccessStatusCode();
        }
    }
}