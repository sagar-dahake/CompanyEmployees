using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    //public interface IEmployeeService
    //{
    //    IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
    //    EmployeeDto GetEmployee(Guid CompanyId, Guid Id, bool trackChanges);

    //    EmployeeDto  CreateEmployeeForCompany(Guid companyID, EmployeeForCreationDto employeeForCreation , bool trackChanges);

    //    void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);

    //    void UpdateEmployeeForCompany(Guid companyId, Guid Id, EmployeeForUpdateDto employeeForUpdateDto, bool companyTrackChanges, bool employeeTrackChanges);

    //    (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch( Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);

    //    void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);

    //}


    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(
            Guid companyId,
            bool trackChanges);

        Task<EmployeeDto?> GetEmployeeAsync(
            Guid companyId,
            Guid id,
            bool trackChanges);

        Task<EmployeeDto> CreateEmployeeForCompanyAsync(
            Guid companyId,
            EmployeeForCreationDto employeeForCreation,
            bool trackChanges);

        Task DeleteEmployeeForCompanyAsync(
            Guid companyId,
            Guid id,
            bool trackChanges);

        Task UpdateEmployeeForCompanyAsync(
            Guid companyId,
            Guid id,
            EmployeeForUpdateDto employeeForUpdateDto,
            bool companyTrackChanges,
            bool employeeTrackChanges);

        Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)>
            GetEmployeeForPatchAsync(
                Guid companyId,
                Guid id,
                bool compTrackChanges,
                bool empTrackChanges);

        Task SaveChangesForPatchAsync(
            EmployeeForUpdateDto employeeToPatch,
            Employee employeeEntity);
    }
}
