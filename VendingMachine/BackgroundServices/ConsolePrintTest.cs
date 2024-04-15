namespace VendingMachine.BackgroundServices
{
    public class ConsolePrintTest : IHostedService
    {
        private readonly ILogger<ConsolePrintTest> _logger;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        public ConsolePrintTest(ILogger<ConsolePrintTest> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            DoSomething(_cancellationTokenSource.Token);
        }

        public async Task DoSomething(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, _cancellationTokenSource.Token);
                    _logger.LogInformation($"{DateTime.Now.ToShortTimeString()} Кукареку");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Всё очень плохо");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
    }
}
