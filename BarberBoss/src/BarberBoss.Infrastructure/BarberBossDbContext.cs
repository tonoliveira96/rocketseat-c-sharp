using BarberBoss.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure
{
    public class BarberBossDbContext : DbContext
    {
        public BarberBossDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Billing> Billings { get; set; }
    }
}
