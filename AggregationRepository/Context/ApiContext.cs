using AggregationRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace AggregationRepository.Context
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AggregationDbInMemory");
        }

        /// <summary>
        /// Collection of Order entities.
        /// </summary>
        public DbSet<Order> Orders { get; set; }
    }
}
