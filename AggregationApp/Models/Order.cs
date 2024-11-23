using System.ComponentModel.DataAnnotations;

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
        [Required]
        public int ProductId {  get; set; }

        /// <summary>
        /// Count of products in the order.
        /// </summary>
        [Required]
        public int Quantity { get; set; }
    }
}
