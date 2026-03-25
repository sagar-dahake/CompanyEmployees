using Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        // new lazy repositories
        private readonly Lazy<ISalaryRepository> _salaryRepository;
        private readonly Lazy<IPayslipRepository> _payslipRepository;
        private readonly Lazy<ILeaveRecordRepository> _leaveRepository;

        // stored procedure repository
        private readonly Lazy<IStoredProcedureRepository> _storedProcedureRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));

            _salaryRepository = new Lazy<ISalaryRepository>(() => new SalaryRepository(repositoryContext));
            _payslipRepository = new Lazy<IPayslipRepository>(() => new PayslipRepository(repositoryContext));
            _leaveRepository = new Lazy<ILeaveRecordRepository>(() => new LeaveRecordRepository(repositoryContext));

            _storedProcedureRepository = new Lazy<IStoredProcedureRepository>(() => new StoredProcedureRepository(repositoryContext));
        }

        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;

        // new repository properties
        public ISalaryRepository Salary => _salaryRepository.Value;
        public IPayslipRepository Payslip => _payslipRepository.Value;
        public ILeaveRecordRepository Leave => _leaveRepository.Value;

        // stored procedure repository
        public IStoredProcedureRepository StoredProcedure => _storedProcedureRepository.Value;

        public async Task  SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}