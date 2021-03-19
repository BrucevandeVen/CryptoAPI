using CryptoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public interface IDataAccess
    {
        IEnumerable<Crypto> GetAll();
        Crypto GetById(int id);
    }
}
