using AggregationApp.Models;
using AggregationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AggregationApp.Controllers
{
    /// <summary>
    /// Controller for aggregation of Orders.
    /// </summary>
    /// <param name="aggregationService">Aggregation service.</param>
    [Route("aggregation/[controller]")]
    [ApiController]
    public class AggregationController(IAggregationService aggregationService) : ControllerBase
    {
        private readonly IAggregationService aggregationService = aggregationService;

        /// <summary>
        /// Returns all orders.
        /// </summary>
        /// <returns>Collection of orders.</returns>
        [HttpGet(Name = "Return all orders")]
        public IActionResult Get()
        {
            return Ok(aggregationService.GetOrders());
        }


        /// <summary>
        /// Aggregate orders according to count.
        /// </summary>
        /// <param name="orders">List of order for aggeragation.</param>
        /// <returns></returns>
        [HttpPost(Name = "Aggregate orders")]
        public IActionResult Post([FromBody] List<Order> orders)
        {
            aggregationService.SaveOrders(orders);
            return Ok();
        }
    }
}
