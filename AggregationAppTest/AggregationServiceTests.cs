using AggregationApp.Models;
using AggregationApp.Services;
using AggregationRepository.Context;
using AggregationRepository.Repository;
using Microsoft.Extensions.Logging.Abstractions;

namespace AggregationAppTest
{
    [TestFixture]
    public class AggregationServiceTests
    {
        IOrderRepository? orderRepository;
        IAggregationService? aggregationService;
        ApiContext apiContext;
        
        [SetUp]
        public void Setup()
        {
            apiContext = new ApiContext();
            orderRepository = new OrderRepository(apiContext, NullLogger<OrderRepository>.Instance);
            aggregationService = new AggregationService(orderRepository);
        }

        [Test]
        public void Aggregate1Orders()
        {
            var order = new List<Order> 
            { 
                new() { ProductId = 1, Quantity = 1 },
                new() { ProductId = 1, Quantity = 3 }
            };
            aggregationService?.SaveOrders(order);

            var res = aggregationService?.GetOrders();

            var count = res?.Count;
            var quantity = res?.First().Quantity;

            Assert.That(count, Is.EqualTo(1));
            Assert.That(quantity, Is.EqualTo(4));
        }

        [Test]
        public void Aggregate2Orders()
        {
            var order = new List<Order>
            {
                new() { ProductId = 1, Quantity = 1 },
                new() { ProductId = 1, Quantity = 3 },
                new() { ProductId = 2, Quantity = 4 }
            };
            aggregationService?.SaveOrders(order);

            var res = aggregationService?.GetOrders();

            var count = res?.Count;
            var firstOrderQuantity = res?.First().Quantity;
            var secondOrderQuantity = res?.Last().Quantity;


            Assert.That(count, Is.EqualTo(2));
            Assert.That(firstOrderQuantity, Is.EqualTo(4));
            Assert.That(secondOrderQuantity, Is.EqualTo(4));
        }

        [Test]
        public void Aggregate3Orders()
        {
            var order = new List<Order>
            {
                new() { ProductId = 1, Quantity = 1 },
                new() { ProductId = 1, Quantity = 3 },
                new() { ProductId = 2, Quantity = 4 },
                new() { ProductId = 3, Quantity = 10 }
            };
            aggregationService?.SaveOrders(order);

            var res = aggregationService?.GetOrders();

            var count = res?.Count;
            var firstOrderQuantity = res?.First().Quantity;
            var secondOrderQuantity = res?.ElementAt(1).Quantity;
            var thirdOrderQuantity = res?.ElementAt(2).Quantity;

            Assert.That(count, Is.EqualTo(3));
            Assert.That(firstOrderQuantity, Is.EqualTo(4));
            Assert.That(secondOrderQuantity, Is.EqualTo(4));
            Assert.That(thirdOrderQuantity, Is.EqualTo(10));
        }

        [TearDown]
        public void TearDown()
        {
            apiContext.Database.EnsureDeleted();
            orderRepository = null;
            aggregationService = null;
        }
    }
}
