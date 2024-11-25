using AggregationRepository.Context;
using AggregationRepository.Repository;
using Microsoft.Extensions.Logging.Abstractions;

namespace AggregationAppTest
{
    public class OrderRepositoryTests
    {
        OrderRepository? orderRepository;
        ApiContext apiContext;

        [SetUp]
        public void Setup()
        {
            apiContext = new ApiContext();
            orderRepository = new OrderRepository(apiContext, NullLogger<OrderRepository>.Instance);
        }

        [Test]
        public void SaveOrder()
        {
            var ord = new AggregationRepository.Entities.Order { ProductId = 1, Quantity = 2 };
            orderRepository?.SaveOrder(ord);

            var count = orderRepository?.GetOrders().Count;
            Assert.That(count, Is.EqualTo(1));  
        }

        [TearDown]
        public void TearDown()
        {
            apiContext.Database.EnsureDeleted();
            orderRepository = null;
        }
    }
}