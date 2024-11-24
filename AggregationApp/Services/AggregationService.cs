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
            foreach (var ord in orders)
            {
                var orderFromDb = orderRepository.GetOrderByProductId(ord.ProductId);
                if (orderFromDb == null)
                {
                    orderRepository.SaveOrder(new AggregationRepository.Entities.Order { ProductId = ord.ProductId, Quantity = ord.Quantity });
                }
                else
                {
                    orderFromDb.Quantity += ord.Quantity;
                    orderRepository.Update(orderFromDb);
                }
            }
        }

        public List<AggregationResult> ExportAggregateOrders()
        {
            var ordersForExport = orderRepository.GetOrders();
            return ordersForExport.Select(t => new AggregationResult { ProductId = t.ProductId, CountOfProducts = t.Quantity }).ToList();
        }
    }
}
