using CreditCardStatementAPI.DTO;
using CreditCardStatementAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;



namespace CreditCardStatementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        private Guid GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException("User ID not found in token.");

            return Guid.Parse(userIdClaim);
        }

        [HttpGet("{statementId}")]
        public async Task<IActionResult> GetTransactions(Guid statementId)
        {
           
            var transactions = await _transactionService.GetTransactionsAsync(statementId);
            return Ok(transactions);
        }

        [HttpPost("{statementId}")]
        public async Task<IActionResult> CreateTransaction(Guid statementId, [FromBody] CreateTransactionDTO dto)
        {
            await _transactionService.CreateTransactionAsync(statementId, dto);
            return Ok(new { message = "Transaction created successfully" });
        }
    }
}

