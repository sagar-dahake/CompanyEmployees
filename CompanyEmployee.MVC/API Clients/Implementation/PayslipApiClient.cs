using CompanyEmployee.MVC.API_Clients.Contracts;
using Shared.DataTransferObjects;


using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CompanyEmployee.MVC.API_Clients.Implementation
{
    public class PayslipApiClient : IPayslipApiClient
    {
        private readonly HttpClient _client;
        public PayslipApiClient(HttpClient client) => _client = client;

        public async Task<List<PayslipDto>> GetByEmployee(Guid employeeId)
        {
            var resp = await _client.GetAsync($"payslip/employee/{employeeId}");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<List<PayslipDto>>();
        }

        public async Task<PayslipDto> Get(Guid employeeId, Guid id)
        {
            var resp = await _client.GetAsync($"payslip/employee/{employeeId}/{id}");
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<PayslipDto>();
        }

        public async Task<PayslipDto> Create(Guid employeeId, PayslipForCreationDto dto)
        {
            var resp = await _client.PostAsJsonAsync($"payslip/employee/{employeeId}", dto);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<PayslipDto>();
        }

        public async Task Update(Guid employeeId, Guid id, PayslipForCreationDto dto)
        {
            var resp = await _client.PutAsJsonAsync($"payslip/employee/{employeeId}/{id}", dto);
            resp.EnsureSuccessStatusCode();
        }

        public async Task Delete(Guid employeeId, Guid id)
        {
            var resp = await _client.DeleteAsync($"payslip/employee/{employeeId}/{id}");
            resp.EnsureSuccessStatusCode();
        }
    }
}