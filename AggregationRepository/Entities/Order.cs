namespace AggregationRepository.Entities
{
    /// <summary>
    /// Represents order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Identifier of order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Count of products in the order.
        /// </summary>
        public int Quantity { get; set; }
    }
}
