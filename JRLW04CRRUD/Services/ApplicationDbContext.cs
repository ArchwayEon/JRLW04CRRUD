using JRLW04CRRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JRLW04CRRUD.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}
