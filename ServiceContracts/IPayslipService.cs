using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.DataTransferObjects;



namespace ServiceContracts
{
    public interface IPayslipService
    {
        Task<IEnumerable<PayslipDto>> GetPayslipsForEmployeeAsync(Guid employeeId, bool trackChanges);
        Task<PayslipDto?> GetPayslipAsync(Guid employeeId, Guid id, bool trackChanges);
        Task<PayslipDto> CreatePayslipForEmployeeAsync(Guid employeeId, PayslipForCreationDto payslipForCreation);
        Task UpdatePayslipForEmployeeAsync(Guid employeeId, Guid id, PayslipForCreationDto payslipForUpdate, bool trackChanges);
        Task DeletePayslipForEmployeeAsync(Guid employeeId, Guid id, bool trackChanges);

        Task<PayslipDto> GeneratePayslipForMonthAsync(Guid employeeId, int year, int month);
    }
}