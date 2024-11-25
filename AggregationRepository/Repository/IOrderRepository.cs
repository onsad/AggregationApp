using AggregationRepository.Entities;

namespace AggregationRepository.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public Order? GetOrderByProductId(int productId);
        public void SaveOrder(Order order);
        public void SaveOrders(List<Order> orders);
        public void Update(Order order);
    }
}
