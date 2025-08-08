using AutoMapper;
using CreditCardStatementAPI.Data;
using CreditCardStatementAPI.DTO;
using CreditCardStatementAPI.Model;
using CreditCardStatementAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;



namespace CreditCardStatementAPI.Services
{
    public class StatementService : IStatementService
    {
        private readonly ApplicationDBContext _context; 
        private readonly IMapper _mapper; 

        public StatementService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<List<StatementDto>> GetStatementsAsync(Guid userId, DateTime start, DateTime end)
        {
            var statements = await _context.Statements
                .Where(s => s.UserId == userId &&
                            s.StatementMonth >= start &&
                            s.StatementMonth <= end)
                .OrderByDescending(s => s.StatementMonth)
                .Include(s => s.Transactions)
                .OrderByDescending(s => s.StatementMonth)
                .ToListAsync();

            return _mapper.Map<List<StatementDto>>(statements);
        }

      
        public async Task CreateStatementAsync(Guid userId, CreateStatementDTO dto)
        {
            var statement = _mapper.Map<Statement>(dto);
            statement.UserId = userId;

            _context.Statements.Add(statement);
            await _context.SaveChangesAsync();
        }

    }
}
