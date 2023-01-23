namespace ServiceWorker
{
    public class BackroundWorkerService : BackgroundService
    {
        private readonly IQueue _queue;
        private readonly ILogger<BackroundWorkerService> _logger;

        public BackroundWorkerService(ILogger<BackroundWorkerService> logger, IQueue queue)
        {
            _logger = logger;
            _queue = queue;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Service running: {DateTimeOffset.Now}");
                try
                {
                    var item = _queue.Dequeue();
                    if (item != null)
                    {
                        _logger.LogInformation($"Execution result: {item.Multiply(item.Value).ToString()}");
                    }
                }
                catch (InvalidOperationException)
                {
                    _logger.LogInformation("No Tasks in queue");
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
