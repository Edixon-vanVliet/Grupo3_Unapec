using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Grupo3_Unapec.Domain.Entities;

namespace Grupo3_Unapec.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Department> Departments => Set<Department>();

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}