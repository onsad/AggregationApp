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
                return context.Orders.ToList();
            }
        }

        public void SaveOrders(List<Order> orders)
        {
            using (var context = new ApiContext())
            {
                foreach (var ord in orders)
                {
                    var orderInDb = context.Orders.SingleOrDefault(o => o.ProductId == ord.ProductId);
                    if (orderInDb != null)
                    {
                        orderInDb.Quantity += ord.Quantity;
                    }
                    else
                    {
                        context.Orders.Add(ord);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
