using System.Text.Json;

namespace AggregationApp.Services
{
    public class ScopedProcessingService(ILogger<ScopedProcessingService> logger, AggregationService aggregationService) : IScopedProcessingService
    {
        private readonly ILogger<ScopedProcessingService> logger = logger;
        private readonly AggregationService aggregationService = aggregationService;

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = this.aggregationService.ExportAggregateOrders();
                logger.LogInformation($"Aggregate orders: {JsonSerializer.Serialize(result)}");

                await Task.Delay(25000, stoppingToken);
            }
        }
    }
}
