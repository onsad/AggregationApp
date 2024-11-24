using AggregationRepository.Context;
using AggregationRepository.Entities;
using Microsoft.Extensions.Logging;

namespace AggregationRepository.Repository
{
    public class OrderRepository(ILogger<OrderRepository> logger)
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

        public List<Order> GetOrdersForExport()
        {
            var exportedOrders = new List<Order>(); 

            using (var context = new ApiContext())
            {
                try
                {
                    var listOrdersForExport = context.Orders.Where(o => !o.IsExported);

                    if (listOrdersForExport.Any())
                    {
                        exportedOrders = listOrdersForExport.ToList();

                        foreach (var order in listOrdersForExport)
                        {
                            order.IsExported = true;
                        }

                        context.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    logger.LogError($"Error: {ex.Message}");
                }
            }

            return exportedOrders;
        }
    }
}
