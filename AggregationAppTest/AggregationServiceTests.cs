using AggregationApp.Services;
using AggregationRepository.Repository;

namespace AggregationAppTest
{
    public class AggregationServiceTests
    {
        OrderRepository orderRepository;
        AggregationService aggregationService;

        [SetUp]
        public void Setup()
        {
            orderRepository = new OrderRepository();
            aggregationService = new AggregationService(orderRepository);
        }

        [Test]
        public void SaveOrders()
        {
            var ord = new AggregationRepository.Entities.Order { ProductId = 1, Quantity = 2 };
            orderRepository.SaveOrder(ord);

            var count = orderRepository.GetOrders().Count;
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
