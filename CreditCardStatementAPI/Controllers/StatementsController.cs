using AutoMapper;
using CreditCardStatementAPI.Data;
using CreditCardStatementAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CreditCardStatementAPI.Services.Interface;


namespace CreditCardStatementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class StatementsController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementsController(IStatementService statementService)
        {
            _statementService = statementService;
        }

        
        private Guid GetUserIdFromToken()
        {
           
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                throw new UnauthorizedAccessException("User ID not found in token.");

            return Guid.Parse(userIdClaim); 
        }

        
        [HttpGet]
        public async Task<IActionResult> GetStatements([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var userId = GetUserIdFromToken(); 
            var statements = await _statementService.GetStatementsAsync(userId, start, end);
            return Ok(statements);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateStatement([FromBody] CreateStatementDTO dto)
        {
            var userId = GetUserIdFromToken(); 
            await _statementService.CreateStatementAsync(userId, dto);
            return Ok(new { message = "Statement created successfully" });
        }
    }
}
