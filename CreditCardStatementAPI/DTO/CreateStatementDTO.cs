namespace CreditCardStatementAPI.DTO
{
    public class CreateStatementDTO
    {
        public DateTime StatementMonth { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AmountDue { get; set; }
        public List<CreateTransactionDTO> Transactions { get; set; } = new List<CreateTransactionDTO>();
    }
}
