using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public class CryptoUpdater : IHostedService, IDisposable
    {
        private readonly ICryptoDataUpdater _cryptoUpdater;

        private Timer timer;

        public CryptoUpdater(ICryptoDataUpdater cryptoUpdater)
        {
            _cryptoUpdater = cryptoUpdater;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(o =>
            {
                Update();
            },
                null,
                TimeSpan.FromSeconds(3),
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Updater stopped");
            return Task.CompletedTask;
        }

        public void Update()
        {
            try
            {
                _cryptoUpdater.Update();
                Console.WriteLine("Updated successfully");
            }
            catch
            {
                Console.WriteLine("Update failed");
            }
        }
    }
}
