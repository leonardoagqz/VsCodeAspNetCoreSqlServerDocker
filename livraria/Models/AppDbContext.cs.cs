using Microsoft.EntityFrameworkCore;


namespace livraria.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
    }

    public DbSet<Livro>?  Livros { get; set; }
}
