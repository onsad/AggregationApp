using AggregationApp.Models;

namespace AggregationApp.Services
{
    /// <summary>
    /// Service for aggregation of orders by identifier of product.
    /// </summary>
    public interface IAggregationService
    {
        /// <summary>
        /// Returns all aggregated orders.
        /// </summary>
        /// <returns>List of orders.</returns>
        public List<Order> GetOrders();

        /// <summary>
        /// Saves colletion of orders for aggregation.
        /// </summary>
        /// <param name="orders">List of orders for aggregation.</param>
        public void SaveOrders(List<Order> orders);
    }
}
