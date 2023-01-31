namespace SignalRProject.Server.BackgroundServices
{
    public class DatetimeLogWriter : IHostedService,IDisposable
    {
        Timer timer;
        public  Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(DatetimeLogWriter)} service started.");

            timer = new Timer(WriteDateTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
            //while (!cancellationToken.IsCancellationRequested)
            //{
            //    WriteDateTime();
            //    await Task.Delay(1000);
            //}
        }

        private void WriteDateTime(object state)
        {
            Console.WriteLine($"Datetime is:{DateTime.Now.ToLongTimeString()}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            Console.WriteLine($"{nameof(DatetimeLogWriter)} service stopped.");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer = null;
        }
    }
}
