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
    internal sealed class LeaveService : ILeaveService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public LeaveService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeaveRecordDto>> GetLeavesForEmployeeAsync(Guid employeeId, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var leaves = await _repositoryManager.Leave.GetLeavesByEmployeeAsync(employeeId, trackChanges);
            return _mapper.Map<IEnumerable<LeaveRecordDto>>(leaves);
        }

        public async Task<LeaveRecordDto?> GetLeaveAsync(Guid employeeId, Guid id, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var leave = await _repositoryManager.Leave.GetLeaveAsync(employeeId, id, trackChanges);
            if (leave is null)
                return null;

            return _mapper.Map<LeaveRecordDto>(leave);
        }

        public async Task<LeaveRecordDto> CreateLeaveForEmployeeAsync(Guid employeeId, LeaveRecordForCreationDto leaveForCreation)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, false);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var leaveEntity = _mapper.Map<LeaveRecord>(leaveForCreation);
            leaveEntity.EmployeeId = employeeId;

            _repositoryManager.Leave.CreateLeaveForEmployee(employeeId, leaveEntity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<LeaveRecordDto>(leaveEntity);
        }

        public async Task UpdateLeaveForEmployeeAsync(Guid employeeId, Guid id, LeaveRecordForUpdateDto leaveForUpdate, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var leaveEntity = await _repositoryManager.Leave.GetLeaveAsync(employeeId, id, trackChanges);
            if (leaveEntity is null)
                throw new KeyNotFoundException($"Leave {id} not found.");

            _mapper.Map(leaveForUpdate, leaveEntity);

            _repositoryManager.Leave.UpdateLeave(leaveEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteLeaveForEmployeeAsync(Guid employeeId, Guid id, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var leaveEntity = await _repositoryManager.Leave.GetLeaveAsync(employeeId, id, trackChanges);
            if (leaveEntity is null)
                throw new KeyNotFoundException($"Leave {id} not found.");

            _repositoryManager.Leave.DeleteLeave(leaveEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}