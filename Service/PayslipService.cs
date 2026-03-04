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
    internal sealed class PayslipService : IPayslipService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PayslipService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PayslipDto>> GetPayslipsForEmployeeAsync(Guid employeeId, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var payslips = await _repositoryManager.Payslip.GetPayslipsByEmployeeAsync(employeeId, trackChanges);
            return _mapper.Map<IEnumerable<PayslipDto>>(payslips);
        }

        public async Task<PayslipDto?> GetPayslipAsync(Guid employeeId, Guid id, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var payslip = await _repositoryManager.Payslip.GetPayslipAsync(employeeId, id, trackChanges);
            if (payslip is null)
                return null;

            return _mapper.Map<PayslipDto>(payslip);
        }

        public async Task<PayslipDto> CreatePayslipForEmployeeAsync(Guid employeeId, PayslipForCreationDto payslipForCreation)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, false);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var payslipEntity = _mapper.Map<Payslip>(payslipForCreation);
            payslipEntity.EmployeeId = employeeId;

            _repositoryManager.Payslip.CreatePayslip(payslipEntity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<PayslipDto>(payslipEntity);
        }

        public async Task UpdatePayslipForEmployeeAsync(Guid employeeId, Guid id, PayslipForCreationDto payslipForUpdate, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var payslipEntity = await _repositoryManager.Payslip.GetPayslipAsync(employeeId, id, trackChanges);
            if (payslipEntity is null)
                throw new KeyNotFoundException($"Payslip {id} not found.");

            _mapper.Map(payslipForUpdate, payslipEntity);

            _repositoryManager.Payslip.UpdatePayslip(payslipEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeletePayslipForEmployeeAsync(Guid employeeId, Guid id, bool trackChanges)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, trackChanges);
            if (employee is null)
                throw new EmployeeNotFoundException(employeeId);

            var payslipEntity = await _repositoryManager.Payslip.GetPayslipAsync(employeeId, id, trackChanges);
            if (payslipEntity is null)
                throw new KeyNotFoundException($"Payslip {id} not found.");

            _repositoryManager.Payslip.DeletePayslip(payslipEntity);
            await _repositoryManager.SaveAsync();
        }

        /// <summary>
        /// Generates a monthly payslip with automatic salary lookup and leave deduction calculation
        /// </summary>
        public async Task<PayslipDto> GeneratePayslipForMonthAsync(Guid employeeId, int year, int month)
        {
            _logger.LogInfo($"Generating payslip for employee {employeeId} for {year}-{month:D2}");

            // 1. Verify employee exists
            var employee = await _repositoryManager.Employee.GetEmployeeByIdAsync(employeeId, false);
            if (employee is null)
            {
                _logger.LogError($"Employee {employeeId} not found.");
                throw new EmployeeNotFoundException(employeeId);
            }

            // 2. Get active salary for the month
            var targetDate = new DateTime(year, month, 1);
            var salary = await _repositoryManager.Salary.GetActiveSalaryAsync(employeeId, targetDate, false);
            if (salary is null)
            {
                var message = $"No active salary found for employee {employeeId} ({employee.Name}) in {year}-{month:D2}";
                _logger.LogError(message);
                throw new InvalidOperationException(message);
            }

            // 3. Check if payslip already exists for this month
            var existing = await _repositoryManager.Payslip.GetPayslipForMonthAsync(employeeId, year, month, false);
            if (existing is not null)
            {
                var message = $"Payslip already exists for employee {employeeId} for {year}-{month:D2}";
                _logger.LogWarn(message);
                throw new InvalidOperationException(message);
            }

            // 4. Calculate leave deductions
            var unpaidLeaveDays = await _repositoryManager.Leave.GetUnpaidLeaveDaysForMonthAsync(employeeId, year, month, false);

            // Business logic: 22 working days per month (adjust as needed)
            const int workingDaysInMonth = 22;
            var dailyRate = (salary.BaseAmount + salary.Allowances) / workingDaysInMonth;
            var leaveDeduction = unpaidLeaveDays * dailyRate;

            _logger.LogInfo($"Unpaid leave days: {unpaidLeaveDays}, Daily rate: {dailyRate:C}, Leave deduction: {leaveDeduction:C}");

            // 5. Calculate payslip amounts
            var grossAmount = salary.BaseAmount + salary.Allowances;

            // Tax calculation (10% flat rate - adjust based on your tax logic)
            var taxAmount = grossAmount * 0.10m;

            var totalDeductions = taxAmount + leaveDeduction;
            var netAmount = grossAmount - totalDeductions;

            _logger.LogInfo($"Gross: {grossAmount:C}, Tax: {taxAmount:C}, Deductions: {leaveDeduction:C}, Net: {netAmount:C}");

            // 6. Create payslip entity
            var payslipEntity = new Payslip
            {
                Id = Guid.NewGuid(),
                EmployeeId = employeeId,
                SalaryId = salary.Id,
                GrossAmount = grossAmount,
                TaxAmount = taxAmount,
                Deductions = leaveDeduction,
                NetAmount = netAmount,
                PayslipDate = new DateTime(year, month, DateTime.DaysInMonth(year, month))
            };

            _repositoryManager.Payslip.CreatePayslip(payslipEntity);
            await _repositoryManager.SaveAsync();

            _logger.LogInfo($"Payslip {payslipEntity.Id} generated successfully for employee {employeeId}");

            return _mapper.Map<PayslipDto>(payslipEntity);
        }
    }
}