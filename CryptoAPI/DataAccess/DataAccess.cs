using CryptoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public class DataAccess : IDataAccess
    {
        public IEnumerable<Crypto> GetAll()
        {
            using (var context = new CryptoMonitorContext())
            {
                return context.Crypto.ToList();
            }
        }

        public Crypto GetById(int id)
        {
            using (var context = new CryptoMonitorContext())
            {
                Crypto crypto = context.Crypto.FirstOrDefault(crypto => crypto.Id == id);

                return crypto;
            }
        }
    }
}
