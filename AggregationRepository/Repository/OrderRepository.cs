using AggregationRepository.Context;
using AggregationRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AggregationRepository.Repository
{
    /// <inheritdoc/>
    public class OrderRepository(ApiContext apiContext, ILogger<OrderRepository> logger) : IOrderRepository
    {
        /// <inheritdoc/>
        public Order? GetOrderByProductId(int productId)
        {
            return apiContext.Orders.FirstOrDefault(o => o.ProductId == productId);
        }

        /// <inheritdoc/>
        public List<Order> GetOrders()
        {
            return apiContext.Orders.ToList();
        }

        /// <inheritdoc/>
        public void SaveOrders(List<Order> orders)
        {
            try
            {
                foreach (var ord in orders)
                {
                    var orderInDb = apiContext.Orders.SingleOrDefault(o => o.ProductId == ord.ProductId);
                    if (orderInDb != null)
                    {
                        orderInDb.Quantity += ord.Quantity;
                    }
                    else
                    {
                        apiContext.Orders.Add(ord);
                    }
                }

                apiContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex.Message);
            }
            
        }

        /// <inheritdoc/>
        public void SaveOrder(Order order)
        {
            try
            {
                apiContext.Orders.Add(order);
                apiContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public void Update(Order order)
        {
            try
            {
                apiContext.Update(order);
                apiContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
