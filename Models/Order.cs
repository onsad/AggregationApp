namespace AggregationApp.Models
{
    /// <summary>
    /// Represents order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Identifier of product.
        /// </summary>
        public int ProductId {  get; set; }

        /// <summary>
        /// Count of products in the order.
        /// </summary>
        public int Quantity { get; set; }
    }
}
