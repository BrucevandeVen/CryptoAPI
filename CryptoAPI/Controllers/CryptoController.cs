﻿using CryptoAPI.DTOs;
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
        public IEnumerable<CryptoDTO> Get()
        {
            IEnumerable<CryptoDTO> cryptos = _dataAccess.GetAll().Select(crypto => crypto.ToDTO());

            return cryptos;
        }

        [HttpGet("{id}")]
        public ActionResult<CryptoDTO> Details(int id)
        {
            CryptoDTO crypto = _dataAccess.GetById(id).ToDTO();

            if (crypto == null)
            {
                return NotFound(new { Message = "Cryptocurrency has not been found" });
            }

            return Ok(crypto);
        }

        // GET: CryptoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CryptoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CryptoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CryptoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CryptoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CryptoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}