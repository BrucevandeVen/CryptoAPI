using System;
using System.Collections.Generic;

#nullable disable

namespace CryptoAPI.Models
{
    public partial class Crypto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
