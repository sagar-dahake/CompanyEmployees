using Contracts;
using Entities.Models.SpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StoredProcedureRepository : IStoredProcedureRepository
    {
        private readonly RepositoryContext _context;

        public StoredProcedureRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<LeaveSummaryResult> GetLeaveSummaryAsync(Guid employeeId, int year)
        {
            var paramEmployeeId = new SqlParameter("@EmployeeId", employeeId);
            var paramYear = new SqlParameter("@Year", year);

            var result = await _context.LeaveSummaryResults
                .FromSqlRaw("EXEC [dbo].[usp_GetLeaveSummary] @EmployeeId, @Year",
                    paramEmployeeId, paramYear)
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault() ?? new LeaveSummaryResult
            {
                EmployeeId = employeeId,
                Year = year
            };
        }
    }
}