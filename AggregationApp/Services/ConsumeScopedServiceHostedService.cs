using AggregationRepository.Context;
using System.Text.Json;

namespace AggregationApp.Services
{
    /// <summary>
    /// Service for exporting aggregated orders.
    /// </summary>
    /// <param name="services">List of services in the application.</param>
    /// <param name="logger">Logger.</param>
    public class ConsumeScopedServiceHostedService(IServiceProvider services, ILogger<ConsumeScopedServiceHostedService> logger) : BackgroundService
    {
        private readonly ILogger<ConsumeScopedServiceHostedService> logger = logger;

        public IServiceProvider Services { get; } = services;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            logger.LogInformation("Consume Scoped Service Hosted Service is working.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = Services.CreateScope())
                {
                    using (var context = scope.ServiceProvider.GetRequiredService<ApiContext>())
                    {
                        var resultOrders = context.Orders.ToList();
                        logger.LogInformation($"Aggregate orders: {JsonSerializer.Serialize(resultOrders)}");
                    }
                }

                await Task.Delay(25000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
