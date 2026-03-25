using Entities.Models.SpResults;

namespace Contracts
{
    public interface IStoredProcedureRepository
    {
        Task<LeaveSummaryResult> GetLeaveSummaryAsync(Guid employeeId, int year);
    }
}