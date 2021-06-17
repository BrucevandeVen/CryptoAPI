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

        public CryptoController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public async Task <ActionResult<List<CryptoDTO>>> Get()
        {
            List<Crypto> cryptos = await _dataAccess.GetAllCryptoAsync();

            List<CryptoDTO> cryptoDTOs = cryptos.Select(crypto => crypto.ToDTO()).ToList();

            if (cryptos == null || cryptos.Count < 1)
            {
                return NotFound();
            }
   
            return Ok(cryptoDTOs);
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<CryptoDTO>> Details(int id)
        {
            Crypto crypto = await _dataAccess.GetCryptoByIdAsync(id);

            if (crypto == null)
            {
                return NotFound(new { Message = "Cryptocurrency has not been found" });
            }

            CryptoDTO cryptoDTO = crypto.ToDTO();

            return Ok(cryptoDTO);
        }

        //[HttpGet("update")]
        //public ActionResult Update()
        //{
        //    try
        //    {
        //        _cryptoUpdater.Update();
        //    }
        //    catch
        //    {
        //        return NotFound(new { Message = "Update Failed" });
        //    }

        //    return Ok(new { Message = "Updated succesfully"});
        //}
    }
}
