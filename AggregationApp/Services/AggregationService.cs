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
            var newOrdersForSave = new List<AggregationRepository.Entities.Order>();

            var aggregateOrders = orders.GroupBy(o => o.ProductId).Select(t => 
                new AggregationRepository.Entities.Order { ProductId = t.Key, Quantity = t.Sum(u => u.Quantity) }
                ).ToList();

            foreach (var ord in aggregateOrders)
            {
                var orderFromDb = orderRepository.GetOrderByProductId(ord.ProductId);
                if (orderFromDb == null)
                {
                    newOrdersForSave.Add(new AggregationRepository.Entities.Order { ProductId = ord.ProductId, Quantity = ord.Quantity });
                }
                else
                {
                    orderFromDb.Quantity += ord.Quantity;
                    orderRepository.Update(orderFromDb);
                }
            }

            if (newOrdersForSave.Any())
            {
                orderRepository.SaveOrders(newOrdersForSave);
            }
        }
    }
}
