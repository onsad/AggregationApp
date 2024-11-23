using AggregationApp.Models;
using System.Collections.Generic;

namespace AggregationApp.Services
{
    public class AggregationService
    {
        public void AggregateOrders(List<Order> orders)
        {
            var result = orders.GroupBy(o => o.ProductId).Select(t => new AggregationResult { ProductId = t.Key, CountOfProducts = t.Sum(u => u.Quantity) }).ToList();
            string s = string.Join("", result);
            Console.WriteLine(s);
        }
    }
}
