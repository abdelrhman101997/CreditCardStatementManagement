using CreditCardStatementAPI.DTO;

namespace CreditCardStatementAPI.Services.Interface
{
    public interface IStatementService
    {
        Task<List<StatementDto>> GetStatementsAsync(Guid userId, DateTime start, DateTime end);

        
        Task CreateStatementAsync(Guid userId, CreateStatementDTO dto);
    }
}
