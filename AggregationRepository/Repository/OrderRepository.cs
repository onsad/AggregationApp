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

        public List<Order> GetOrdersForExport()
        {
            var exportedOrders = new List<Order>(); 

            using (var context = new ApiContext())
            //using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var listOrdersForExport = context.Orders.Where(o => !o.IsExported);

                    if (listOrdersForExport.Any())
                    {
                        exportedOrders = listOrdersForExport.ToList();

                        //listOrdersForExport.ExecuteUpdate(b => b.SetProperty(o => o.IsExported, true));
                        foreach (var order in listOrdersForExport)
                        {
                            order.IsExported = true;
                        }

                        context.SaveChanges();

                        //dbContextTransaction.Commit();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    //dbContextTransaction.Rollback();
                }
            }

            return exportedOrders;
        }
    }
}
