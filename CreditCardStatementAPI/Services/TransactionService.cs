using AutoMapper;
using CreditCardStatementAPI.Data;
using CreditCardStatementAPI.DTO;
using CreditCardStatementAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using CreditCardStatementAPI.Model;


namespace CreditCardStatementAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public TransactionService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TransactionDto>> GetTransactionsAsync(Guid statementId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.StatementId == statementId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();

            return _mapper.Map<List<TransactionDto>>(transactions);
        }

        public async Task CreateTransactionAsync(Guid statementId, CreateTransactionDTO dto)
        {
            var transaction = _mapper.Map<Transaction>(dto);
            transaction.StatementId = statementId;

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
