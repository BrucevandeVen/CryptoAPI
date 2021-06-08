using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoAPI.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<CryptoMonitorContext>());
            }

        }

        public static void SeedData(CryptoMonitorContext context)
        {
            Console.WriteLine("Applying Migrations...");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception)
            {
                Console.WriteLine("Migrations failed");
            }

            try
            {
                if (!context.Crypto.Any())
                {
                    context.Crypto.AddRange(
                        new Crypto() { Name = "Bitcoin", Price = 2000 },
                        new Crypto() { Name = "Ethereum", Price = 2000 },
                        new Crypto() { Name = "Cardano", Price = 2000 },
                        new Crypto() { Name = "Dogecoin", Price = 2000 },
                        new Crypto() { Name = "Polkadot", Price = 2000 },
                        new Crypto() { Name = "Internet Computer", Price = 2000 },
                        new Crypto() { Name = "Tether", Price = 2000 },
                        new Crypto() { Name = "Icon", Price = 2000 },
                        new Crypto() { Name = "Holo", Price = 2000 },
                        new Crypto() { Name = "Bitcoin Cash", Price = 2000 }
                    );
                    context.SaveChanges();
                }
                {
                    Console.WriteLine("Not seeding, Data already apperend");
                }
            }
            catch 
            {
                Console.WriteLine("seeding failed");
            }
        }
    }
}
