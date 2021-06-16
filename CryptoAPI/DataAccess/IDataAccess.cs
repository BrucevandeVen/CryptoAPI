using CryptoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public interface IDataAccess
    {
        Task <List<Crypto>> GetAllCryptoAsync();
        Task <Crypto> GetCryptoByIdAsync(int id);
    }
}
