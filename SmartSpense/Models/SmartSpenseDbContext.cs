using Microsoft.EntityFrameworkCore;

namespace SmartSpense.Models
{
    public class SmartSpenseDbContext:DbContext
    {
       public DbSet<Expense> Expenses {  get; set; }
        public SmartSpenseDbContext(DbContextOptions<SmartSpenseDbContext>options):base(options)
        {
            
        }
    }
}
