using CompanyEmployee.MVC.API_Clients.Contracts;
using Shared.DataTransferObjects;


using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.API_Clients.Implementation
{
    public class SalaryApiClient : ISalaryApiClient
    {
        private readonly HttpClient _client;

        public SalaryApiClient(HttpClient client) => _client = client;

        public async Task<List<SalaryDto>> GetByEmployee(Guid employeeId)
        {
            var resp = await _client.GetAsync($"salary/employee/{employeeId}");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<List<SalaryDto>>();
        }

        public async Task<SalaryDto> Get(Guid employeeId, Guid id)
        {
            var resp = await _client.GetAsync($"salary/employee/{employeeId}/{id}");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<SalaryDto>();
        }

        public async Task<SalaryDto> Create(Guid employeeId, SalaryForCreationDto dto)
        {
            var resp = await _client.PostAsJsonAsync($"salary/employee/{employeeId}", dto);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<SalaryDto>();
        }

        public async Task Update(Guid employeeId, Guid id, SalaryForUpdateDto dto)
        {
            var resp = await _client.PutAsJsonAsync($"salary/employee/{employeeId}/{id}", dto);
            resp.EnsureSuccessStatusCode();
        }

        public async Task Delete(Guid employeeId, Guid id)
        {
            var resp = await _client.DeleteAsync($"salary/employee/{employeeId}/{id}");
            resp.EnsureSuccessStatusCode();
        }
    }
}