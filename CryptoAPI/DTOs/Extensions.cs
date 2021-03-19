using CryptoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI.DTOs
{
    public static class Extensions
    {
        public static CryptoDTO ToDTO(this Crypto crypto)
        {
            return new CryptoDTO
            {
                Id = crypto.Id,
                Name = crypto.Name,
                Price = crypto.Price
            };
        }
    }
}
