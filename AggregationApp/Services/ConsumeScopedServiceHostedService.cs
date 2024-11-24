namespace AggregationApp.Services
{
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

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
