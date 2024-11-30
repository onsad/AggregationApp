using AggregationRepository.Entities;

namespace AggregationRepository.Repository
{
    /// <summary>
    /// Order repository.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Returns all orders.
        /// </summary>
        /// <returns>List of orders.</returns>
        public List<Order> GetOrders();

        /// <summary>
        /// Returns order by identifier of product.
        /// </summary>
        /// <param name="productId">Identifier of product.</param>
        /// <returns>Order.</returns>
        public Order? GetOrderByProductId(int productId);

        /// <summary>
        /// Saves order.
        /// </summary>
        /// <param name="order">Order for save.</param>
        public void SaveOrder(Order order);

        /// <summary>
        /// Saves orders.
        /// </summary>
        /// <param name="orders">List of orders for save.</param>
        public void SaveOrders(List<Order> orders);

        /// <summary>
        /// Updates of order.
        /// </summary>
        /// <param name="order">Order for update.</param>
        public void Update(Order order);
    }
}
