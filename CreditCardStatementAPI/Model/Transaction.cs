namespace CreditCardStatementAPI.Model
{
    public class Transaction
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime Date { get; set; } = DateTime.MinValue;

       
        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public Guid StatementId { get; set; }

        public Statement Statement { get; set; } = null!;
    }
}
