
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(
                    Guid companyId,
                    bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeesFromDb = await _repositoryManager.Employee.GetEmployeesAsync(companyId,
trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;
        }

        public async Task<EmployeeDto?> GetEmployeeAsync(
                   Guid companyId,
                   Guid id,
                   bool trackChanges)
        {
            // Await the company lookup to avoid overlapping DbContext operations
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeDb = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id, trackChanges);
            if (employeeDb is null)
                throw new EmployeeNotFoundException(id);

            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(
                  Guid companyId,
                  EmployeeForCreationDto employeeForCreation,
                  bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

            _repositoryManager.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repositoryManager.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeToReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(
                    Guid companyId,
                    Guid id,
                    bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeForCompany = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id,
           trackChanges);
            if (employeeForCompany is null)
                throw new EmployeeNotFoundException(id);

            _repositoryManager.Employee.DeleteEmployee(employeeForCompany);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateEmployeeForCompanyAsync(
                    Guid companyId,
                    Guid id,
                    EmployeeForUpdateDto employeeForUpdateDto,
                    bool companyTrackChanges,
                    bool employeeTrackChanges)
        {
            // Await company check to ensure the first DB operation completes before next one starts
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, companyTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id,
            employeeTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(id);
            _mapper.Map(employeeForUpdateDto, employeeEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)>
                    GetEmployeeForPatchAsync(
                        Guid companyId,
                        Guid id,
                        bool compTrackChanges,
                        bool empTrackChanges)
        {
            // Await company lookup here as well
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id,
           empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(companyId);

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            return (employeeToPatch, employeeEntity);
        }

        public async Task SaveChangesForPatchAsync(
                    EmployeeForUpdateDto employeeToPatch,
                    Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
            await _repositoryManager.SaveAsync();
        }

    }
}