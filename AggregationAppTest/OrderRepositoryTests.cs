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

        [Test]
        public void SaveOrders()
        {
            var ord = new List<AggregationRepository.Entities.Order> 
            { 
                new AggregationRepository.Entities.Order { ProductId = 1, Quantity = 2 },
                new AggregationRepository.Entities.Order { ProductId = 2, Quantity = 2 },
                new AggregationRepository.Entities.Order { ProductId = 3, Quantity = 2 }
            };
            orderRepository?.SaveOrders(ord);

            var count = orderRepository?.GetOrders().Count;
            Assert.That(count, Is.EqualTo(3));
        }

        [TearDown]
        public void TearDown()
        {
            apiContext.Database.EnsureDeleted();
            orderRepository = null;
        }
    }
}