using AggregationApp.Models;
using AggregationRepository.Repository;
using System.Text.Json;

namespace AggregationApp.Services
{
    public class AggregationService(OrderRepository orderRepository)
    {
        public List<Order> GetOrders()
        {
            var ord = orderRepository.GetOrders().Select(o => new Order { ProductId = o.ProductId, Quantity = o.Quantity }).ToList();
            return ord;
        }

        public void SaveOrders(List<Order> orders)
        {
            var or = orders.Select(o => new AggregationRepository.Entities.Order { ProductId = o.ProductId, Quantity = o.Quantity }).ToList();
            orderRepository.SaveOrders(or);
        }

        public void AggregateOrders(List<Order> orders)
        {
            var result = orders.GroupBy(o => o.ProductId).Select(t => new AggregationResult { ProductId = t.Key, CountOfProducts = t.Sum(u => u.Quantity) }).ToList();
            string s = JsonSerializer.Serialize(result);
            Console.WriteLine(s);
        }
    }
}
