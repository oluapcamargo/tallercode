using CodeInterview.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CodeInterview.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Users> Users { get; set; }
}
