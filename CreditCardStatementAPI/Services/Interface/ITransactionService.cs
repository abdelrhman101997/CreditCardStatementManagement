using CreditCardStatementAPI.DTO;

namespace CreditCardStatementAPI.Services.Interface
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetTransactionsAsync(Guid statementId);
        Task CreateTransactionAsync(Guid statementId, CreateTransactionDTO dto);
    }
}
