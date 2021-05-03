using Microsoft.EntityFrameworkCore;

namespace Cards.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Deck> Decks { get; set; }
    }
}