////using CompanyEmployee.MVC.API_Clients.Contracts;
////using CompanyEmployee.MVC.Models.Dtos.Employee;

////namespace CompanyEmployee.MVC.API_Clients.Implementation
////{
////    public class EmployeeApiClient : IEmployeeApiClient
////    {
////        private readonly HttpClient _client;

////        public EmployeeApiClient(HttpClient client)
////        {
////            _client = client;
////        }

////        public async Task<List<EmployeeDto>> GetAll(Guid companyId)
////        {
////            var response = await _client.GetAsync($"companies/{companyId}/employees");

////            response.EnsureSuccessStatusCode();

////            return await response.Content
////                .ReadFromJsonAsync<List<EmployeeDto>>();
////        }

////        public async Task<EmployeeDto> Get(Guid companyId, Guid id)
////        {
////            var response = await _client.GetAsync(
////                $"companies/{companyId}/employees/{id}");

////            response.EnsureSuccessStatusCode();

////            return await response.Content
////                .ReadFromJsonAsync<EmployeeDto>();
////        }

////        public async Task Create(Guid companyId, EmployeeCreateDto employee)
////        {
////            var response = await _client.PostAsJsonAsync(
////                $"companies/{companyId}/employees",
////                employee);

////            response.EnsureSuccessStatusCode();
////        }

////        public async Task Update(Guid companyId, Guid id, EmployeeUpdateDto employee)
////        {
////            var response = await _client.PutAsJsonAsync(
////                $"companies/{companyId}/employees/{id}",
////                employee);

////            response.EnsureSuccessStatusCode();
////        }


////        public async Task Delete(Guid companyId, Guid id)
////        {
////            var response = await _client.DeleteAsync(
////                $"companies/{companyId}/employees/{id}");

////            response.EnsureSuccessStatusCode();
////        }




////    }

////}



//using CompanyEmployee.MVC.API_Clients.Contracts;
//using CompanyEmployee.MVC.Models.Dtos.Employee;


//using System.Net.Http;
//using System.Net.Http.Json;

//namespace CompanyEmployee.MVC.API_Clients.Implementation
//{
//    public class EmployeeApiClient : IEmployeeApiClient
//    {
//        private readonly HttpClient _client;

//        public EmployeeApiClient(HttpClient client)
//        {
//            _client = client;
//        }

//        public async Task<List<EmployeeDto>> GetAll(Guid companyId)
//        {
//            // controller route is "api/companies/{companyId}/employees"
//            var response = await _client.GetAsync($"api/companies/{companyId}/employees");

//            response.EnsureSuccessStatusCode();

//            return await response.Content
//                .ReadFromJsonAsync<List<EmployeeDto>>();
//        }

//        public async Task<EmployeeDto> Get(Guid companyId, Guid id)
//        {
//            var response = await _client.GetAsync(
//                $"api/companies/{companyId}/employees/{id}");

//            response.EnsureSuccessStatusCode();

//            return await response.Content
//                .ReadFromJsonAsync<EmployeeDto>();
//        }

//        public async Task Create(Guid companyId, EmployeeCreateDto employee)
//        {
//            var response = await _client.PostAsJsonAsync(
//                $"api/companies/{companyId}/employees",
//                employee);

//            response.EnsureSuccessStatusCode();
//        }

//        public async Task Update(Guid companyId, Guid id, EmployeeUpdateDto employee)
//        {
//            var response = await _client.PutAsJsonAsync(
//                $"api/companies/{companyId}/employees/{id}",
//                employee);

//            response.EnsureSuccessStatusCode();
//        }

//        public async Task Delete(Guid companyId, Guid id)
//        {
//            var response = await _client.DeleteAsync(
//                $"api/companies/{companyId}/employees/{id}");

//            response.EnsureSuccessStatusCode();
//        }
//    }
//}







using CompanyEmployee.MVC.API_Clients.Contracts;
using CompanyEmployee.MVC.Models.Dtos.Employee;



using System.Net.Http;
using System.Net.Http.Json;

namespace CompanyEmployee.MVC.API_Clients.Implementation
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly HttpClient _client;

        public EmployeeApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<EmployeeDto>> GetAll(Guid companyId)
        {
            // BaseAddress already contains the api segment — call the controller route relative to that base.
            var response = await _client.GetAsync($"companies/{companyId}/employees");

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<List<EmployeeDto>>();
        }

        public async Task<EmployeeDto> Get(Guid companyId, Guid id)
        {
            var response = await _client.GetAsync(
                $"companies/{companyId}/employees/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<EmployeeDto>();
        }

        public async Task Create(Guid companyId, EmployeeCreateDto employee)
        {
            var response = await _client.PostAsJsonAsync(
                $"companies/{companyId}/employees",
                employee);

            response.EnsureSuccessStatusCode();
        }

        public async Task Update(Guid companyId, Guid id, EmployeeUpdateDto employee)
        {
            var response = await _client.PutAsJsonAsync(
                $"companies/{companyId}/employees/{id}",
                employee);

            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(Guid companyId, Guid id)
        {
            var response = await _client.DeleteAsync(
                $"companies/{companyId}/employees/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}