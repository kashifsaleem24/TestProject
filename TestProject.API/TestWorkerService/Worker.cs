using Hangfire;

namespace TestWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IServiceProvider _serviceProvider;


        public Worker(ILogger<Worker> logger, IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _recurringJobManager = recurringJobManager;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _recurringJobManager.AddOrUpdate(
                 "upsert-job", // Job identifier
                 () => ExecuteUpsertJob(), // Job to execute
                 Cron.Hourly); // Set to run hourly

            return Task.CompletedTask;
        }

        public void ExecuteUpsertJob()
        {
            // Execute the job (in this case, calling the method in the class library)
            using (var scope = _serviceProvider.CreateScope())
            {
                var upsertJob = scope.ServiceProvider.GetRequiredService<UpsertJob>();
                upsertJob.ExecuteUpsert();
            }

            _logger.LogInformation("Upsert job executed at: {time}", DateTimeOffset.Now);
        }

    }
}
