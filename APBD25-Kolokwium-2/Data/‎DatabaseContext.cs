using Microsoft.EntityFrameworkCore;

namespace APBD25_Kolokwium_2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //tu dane będą np...
        // modelBuilder.Entity<Client>().HasData(new List<Client>()
        // {
            // new Client() { Id = 1, FirstName = "John", LastName = "Doe" },
            // new Client() { Id = 2, FirstName = "Jane", LastName = "Doe" },
            // new Client() { Id = 3, FirstName = "Julie", LastName = "Doe" },
        // });

    }
}