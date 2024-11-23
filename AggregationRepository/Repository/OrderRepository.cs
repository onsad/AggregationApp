using AggregationRepository.Context;
using AggregationRepository.Entities;

namespace AggregationRepository.Repository
{
    public class OrderRepository
    {
        public List<Order> GetOrders()
        {
            using (var context = new ApiContext())
            {
                var list = context.Orders.ToList();
                return list;
            }
        }

        public void SaveOrders(List<Order> orders)
        {
            using (var context = new ApiContext())
            {
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
}
