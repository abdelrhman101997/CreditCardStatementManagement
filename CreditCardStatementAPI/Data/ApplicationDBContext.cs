using CreditCardStatementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CreditCardStatementAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options) { }

        public DbSet<Statement> Statements => Set<Statement>();
        public DbSet<Transaction> Transactions => Set<Transaction>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Statement>()
                 .HasIndex(s => new { s.UserId, s.StatementMonth })
                 .IsUnique();


        
            modelBuilder.Entity<Statement>()
                .HasMany(s => s.Transactions)
                .WithOne(t => t.Statement)
                .HasForeignKey(t => t.StatementId);

            
            modelBuilder.Entity<Statement>()
                .Property(s => s.AmountDue)
                .HasPrecision(18, 2); 

           
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }

    }
}
