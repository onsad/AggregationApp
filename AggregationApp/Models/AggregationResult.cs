namespace AggregationApp.Models
{
    /// <summary>
    /// Rrepresnts result of aggregation.
    /// </summary>
    public class AggregationResult
    {
        /// <summary>
        /// Identifier of product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Aggregate sum of products.
        /// </summary>
        public int CountOfProducts { get; set; }
    }
}
