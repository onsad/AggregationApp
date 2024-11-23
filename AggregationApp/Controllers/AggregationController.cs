﻿using AggregationApp.Models;
using AggregationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AggregationApp.Controllers
{
    [Route("aggregation/[controller]")]
    [ApiController]
    public class AggregationController(AggregationService aggregationService) : ControllerBase
    {
        private readonly AggregationService aggregationService = aggregationService;

        /// <summary>
        /// Returns all orders.
        /// </summary>
        /// <returns></returns>
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
