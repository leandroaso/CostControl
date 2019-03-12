using CostControl.Domain.Entities;
using CostControl.Shared;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Infra.DataContext
{
    public class CostControlContext : DbContext
    {

        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
