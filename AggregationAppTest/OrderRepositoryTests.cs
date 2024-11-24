using AggregationRepository.Repository;

namespace AggregationAppTest
{
    public class OrderRepositoryTests
    {
        OrderRepository orderRepository;

        [SetUp]
        public void Setup()
        {
            orderRepository = new OrderRepository();
        }

        [Test]
        public void SaveOrder()
        {
            var ord = new AggregationRepository.Entities.Order { ProductId = 1, Quantity = 2 };
            orderRepository.SaveOrder(ord);

            var count = orderRepository.GetOrders().Count;
            Assert.That(count, Is.EqualTo(1));  
        }
    }
}