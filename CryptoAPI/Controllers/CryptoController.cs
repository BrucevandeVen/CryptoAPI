using CryptoAPI.DTOs;
using CryptoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CryptoController : Controller
    {
        private readonly IDataAccess _dataAccess;
        private readonly ICryptoDataUpdater _cryptoUpdater;

        public CryptoController(IDataAccess dataAccess, ICryptoDataUpdater cryptoUpdater)
        {
            _dataAccess = dataAccess;
            _cryptoUpdater = cryptoUpdater;
            //test2=3
        }

        [HttpGet]
        public async Task <IEnumerable<CryptoDTO>> Get()
        {
            IEnumerable<Crypto> cryptos = await _dataAccess.GetAll();

            IEnumerable<CryptoDTO> cryptoDTOs = cryptos.ToList().Select(crypto => crypto.ToDTO());
   
            return cryptoDTOs;
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<CryptoDTO>> Details(int id)
        {
            Crypto crypto = await _dataAccess.GetById(id);

            if (crypto == null)
            {
                return NotFound(new { Message = "Cryptocurrency has not been found" });
            }

            CryptoDTO cryptoDTO = crypto.ToDTO();

            return Ok(cryptoDTO);
        }

        [HttpGet("update")]
        public ActionResult Update()
        {
            try
            {
                _cryptoUpdater.Update();
            }
            catch
            {
                return NotFound(new { Message = "Update Failed" });
            }

            return Ok(new { Message = "Updated succesfully"});
        }
    }
}
