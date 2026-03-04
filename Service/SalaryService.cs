using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using ServiceContracts;

using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class SalaryService : ISalaryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SalaryService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalaryDto>> GetSalariesForEmployeeAsync(Guid employeeId, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var salaries = await _repositoryManager.Salary.GetSalariesByEmployeeAsync(employeeId, trackChanges);
            return _mapper.Map<IEnumerable<SalaryDto>>(salaries);
        }

        public async Task<SalaryDto?> GetSalaryAsync(Guid employeeId, Guid id, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var salary = await _repositoryManager.Salary.GetSalaryAsync(employeeId, id, trackChanges);
            if (salary is null)
                return null;

            return _mapper.Map<SalaryDto>(salary);
        }

        public async Task<SalaryDto> CreateSalaryForEmployeeAsync(Guid employeeId, SalaryForCreationDto salaryForCreation)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, false);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var salaryEntity = _mapper.Map<Salary>(salaryForCreation);
            _repositoryManager.Salary.CreateSalaryForEmployee(employeeId, salaryEntity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<SalaryDto>(salaryEntity);
        }

        public async Task UpdateSalaryForEmployeeAsync(Guid employeeId, Guid id, SalaryForUpdateDto salaryForUpdate, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var salaryEntity = await _repositoryManager.Salary.GetSalaryAsync(employeeId, id, trackChanges);
            if (salaryEntity is null)
                throw new KeyNotFoundException($"Salary {id} not found.");

            _mapper.Map(salaryForUpdate, salaryEntity);

            _repositoryManager.Salary.UpdateSalary(salaryEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteSalaryForEmployeeAsync(Guid employeeId, Guid id, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var salaryEntity = await _repositoryManager.Salary.GetSalaryAsync(employeeId, id, trackChanges);
            if (salaryEntity is null)
                throw new KeyNotFoundException($"Salary {id} not found.");

            _repositoryManager.Salary.DeleteSalary(salaryEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}