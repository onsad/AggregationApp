using AggregationApp.Models;
using AggregationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AggregationApp.Controllers
{
    [Route("aggregation/[controller]")]
    [ApiController]
    public class AggregationController : ControllerBase
    {
        private readonly AggregationService aggregationService;
        public AggregationController(AggregationService aggregationService) 
        {
            this.aggregationService = aggregationService;
        }

        /// <summary>
        /// Aggeragate orders according to count.
        /// </summary>
        /// <param name="orders">List of order for aggeragation.</param>
        /// <returns></returns>
        [HttpPost(Name = "Agggregate orders")]
        public IActionResult Post(List<Order> orders)
        {
            this.aggregationService.AggregateOrders(orders);
            return Ok();
        }
    }
}
