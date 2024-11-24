using AggregationApp.Models;
using AggregationRepository.Entities;
using AggregationRepository.Repository;
using System.Text.Json;

namespace AggregationApp.Services
{
    public class AggregationService(OrderRepository orderRepository)
    {
        public List<Models.Order> GetOrders()
        {
            var ord = orderRepository.GetOrders().Select(o => new Models.Order { ProductId = o.ProductId, Quantity = o.Quantity }).ToList();
            return ord;
        }

        public void SaveOrders(List<Models.Order> orders)
        {
            var or = orders.Select(o => new AggregationRepository.Entities.Order { ProductId = o.ProductId, Quantity = o.Quantity }).ToList();
            orderRepository.SaveOrders(or);
        }

        public void ExportAggregateOrders()
        {
            var ordersForExport = orderRepository.GetOrdersForExport();
            var aggregateOrders = ordersForExport.GroupBy(o => o.ProductId).Select(t => new AggregationResult { ProductId = t.Key, CountOfProducts = t.Sum(u => u.Quantity) }).ToList();
            string s = JsonSerializer.Serialize(aggregateOrders);
            Console.WriteLine(s);
        }
    }
}
