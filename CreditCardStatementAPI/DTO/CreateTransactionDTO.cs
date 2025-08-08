namespace CreditCardStatementAPI.DTO
{
    public class CreateTransactionDTO
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
