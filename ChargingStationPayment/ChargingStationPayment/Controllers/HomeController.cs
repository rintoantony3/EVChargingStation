using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChargingStationPayment.Data;
using ChargingStationPayment.Data.Models;

namespace ChargingStationPayment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly DataCon _context;

        public HomeController(ILogger<HomeController> logger, DataCon con)
        {
            _logger = logger;
            _context = con;
        }

        [HttpGet("GetCities")]
        public List<Cities> GetCities()
        {
            return _context.Cities.ToList();
        }

        [HttpPost("StartCharging")]
        public async Task<JsonResult> StartCharging(Transactions tx)
        {
            tx.StartTime = DateTime.Now;
            tx.EndTime = DateTime.Now.AddHours(1);
            await _context.AddAsync(tx);
            await _context.SaveChangesAsync();
            return new JsonResult(new
            {
                tx.TxID
            });
        }

        [HttpPut("StopCharging")]
        public async Task<JsonResult> StopCharging(Transactions tx)
        {
            Transactions dbTx = _context.Transactions.FirstOrDefault(x => x.TxID == tx.TxID);
            dbTx.EndTime = DateTime.Now;
            dbTx.ChargingTimeSeconds = (dbTx.EndTime - dbTx.StartTime).TotalSeconds;
            dbTx.PayableAmount = dbTx.ChargingTimeSeconds * _context.Cities.Where(x => x.CityID == dbTx.CityID).Select(x => x.CityChargeRatePerSecond).FirstOrDefault();
            await _context.SaveChangesAsync();
            return new JsonResult(new
            {
                tx.TxID
            });
        }

        [HttpGet("GetTransaction")]
        public Transactions GetCities(double id)
        {
            return _context.Transactions.Where(x => x.TxID == id)
                .Select(x => new Transactions
            {
                TxID = x.TxID,
                CityChargeRatePerSecond = _context.Cities.Where(y => y.CityID == x.CityID).Select(y => y.CityChargeRatePerSecond).FirstOrDefault(),
                ChargingTimeSeconds = x.ChargingTimeSeconds,
                PayableAmount = x.PayableAmount
            }).FirstOrDefault();
        }
    }
}
