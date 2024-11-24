using System.ComponentModel.DataAnnotations;

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
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Identifier of product.
        /// </summary>
        [Required]
        public int ProductId { get; set; }

        /// <summary>
        /// Count of products in the order.
        /// </summary>
        [Required]
        public int Quantity { get; set; }
    }
}
