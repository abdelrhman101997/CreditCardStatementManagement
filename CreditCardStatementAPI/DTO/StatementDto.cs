namespace CreditCardStatementAPI.DTO
{
    public class StatementDto
    {
        public Guid Id { get; set; }
        public DateTime StatementMonth { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountDue { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();
    }
}
