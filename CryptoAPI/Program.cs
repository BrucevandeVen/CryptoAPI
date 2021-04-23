using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Updater();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void Updater()
        {
            CryptoDataUpdater cryptoDataUpdater = new CryptoDataUpdater();
            CryptoUpdater _cryptoUpdater = new CryptoUpdater(cryptoDataUpdater);

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(2);

            var timer = new System.Threading.Timer((e) =>
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

            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}
