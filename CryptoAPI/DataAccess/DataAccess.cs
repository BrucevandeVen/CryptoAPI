using CryptoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public class DataAccess : IDataAccess
    {
        public async Task <IEnumerable<Crypto>> GetAll()
        {
            using (var context = new CryptoMonitorContext())
            {
                return await context.Crypto.ToListAsync();
            }
        }

        public async Task <Crypto> GetById(int id)
        {
            using (var context = new CryptoMonitorContext())
            {
                return await context.Crypto.FirstOrDefaultAsync(crypto => crypto.Id == id);
            }
        }
    }
}
