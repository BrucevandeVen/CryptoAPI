using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI
{
    public class CryptoUpdater
    {
        private readonly ICryptoDataUpdater _cryptoUpdater;

        public CryptoUpdater(ICryptoDataUpdater cryptoUpdater)
        {
            _cryptoUpdater = cryptoUpdater;
        }

        public void Update()
        {
            _cryptoUpdater.Update();
        }
    }
}
