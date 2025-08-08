namespace CreditCardStatementAPI.Model
{
    public class Statement
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

       
        public DateTime StatementMonth { get; set; } = DateTime.MinValue;

        public DateTime DueDate { get; set; } = DateTime.MinValue;

        public decimal AmountDue { get; set; }

        
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
