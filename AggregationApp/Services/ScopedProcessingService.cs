namespace AggregationApp.Services
{
    public class ScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger logger;
        private readonly AggregationService aggregationService;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, AggregationService aggregationService)
        {
            this.logger = logger;
            this.aggregationService = aggregationService;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this.aggregationService.ExportAggregateOrders();

                await Task.Delay(25000, stoppingToken);
            }
        }
    }
}
