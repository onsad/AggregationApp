using AggregationApp.Models;
using AggregationRepository.Repository;

namespace AggregationApp.Services
{
    public class AggregationService(OrderRepository orderRepository)
    {
        public List<Order> GetOrders()
        {
            return orderRepository.GetOrders().Select(o => new Order { ProductId = o.ProductId, Quantity = o.Quantity }).ToList();
        }

        public void SaveOrders(List<Order> orders)
        {
            var or = orders.Select(o => new AggregationRepository.Entities.Order { ProductId = o.ProductId, Quantity = o.Quantity }).ToList();
            orderRepository.SaveOrders(or);
        }

        public List<AggregationResult> ExportAggregateOrders()
        {
            var ordersForExport = orderRepository.GetOrders();
            return ordersForExport.Select(t => new AggregationResult { ProductId = t.ProductId, CountOfProducts = t.Quantity }).ToList();
        }
    }
}
