using AggregationApp.Models;
using AggregationRepository.Repository;

namespace AggregationApp.Services
{
    public class AggregationService(OrderRepository orderRepository, ILogger<AggregationService> logger)
    {
        private readonly ILogger<AggregationService> logger = logger;

        public List<Order> GetOrders()
        {
            return orderRepository.GetOrders().Select(o => new Order { ProductId = o.ProductId, Quantity = o.Quantity }).ToList();
        }

        public void SaveOrders(List<Order> orders)
        {
            var or = orders.Select(o => new AggregationRepository.Entities.Order { ProductId = o.ProductId, Quantity = o.Quantity, IsExported = false }).ToList();
            orderRepository.SaveOrders(or);
        }

        public List<AggregationResult> ExportAggregateOrders()
        {
            var ordersForExport = orderRepository.GetOrdersForExport();
            return ordersForExport.GroupBy(o => o.ProductId).Select(t => new AggregationResult { ProductId = t.Key, CountOfProducts = t.Sum(u => u.Quantity) }).ToList();
        }
    }
}
