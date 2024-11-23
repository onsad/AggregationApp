using AggregationRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace AggregationRepository.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AggregationDbInMemory");
        }

        public DbSet<Order> Orders { get; set; }
    }
}
