using CryptoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public interface IDataAccess
    {
        Task <IEnumerable<Crypto>> GetAll();
        Task <Crypto> GetById(int id);
    }
}
