using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test_IBA.Models;
using Test_IBA.Repositories;

namespace Test_IBA.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SpeedAccountingController : ControllerBase
    {
        private readonly ITransportInfo _transportInfo;

        public SpeedAccountingController(ITransportInfo transportInfo)
        {
            _transportInfo = transportInfo;

        }

        [HttpGet(@"{date:regex(^([[0-2]][[0-9]]|(3)[[0-1]])(\.)(((0)[[0-9]])|((1)[[0-2]]))(\.)\d{{4}})}")]
        public ActionResult<List<TransportInfo>> GetMaxAndMinTransportInfo(string date)
        {
            if (DateTime.Now > DateTime.ParseExact(Environment.GetEnvironmentVariable("TIME START"), "HH:mm", null)
                && DateTime.Now < DateTime.ParseExact(Environment.GetEnvironmentVariable("TIME END"), "HH:mm", null))
            {
                return _transportInfo.GetMaxAndMinTransportInfo(date);
            }

            return StatusCode(418);
        }

        [HttpGet(@"{date:regex(^([[0-2]][[0-9]]|(3)[[0-1]])(\.)(((0)[[0-9]])|((1)[[0-2]]))(\.)\d{{4}})}/{speed:Double}")]
        public ActionResult<List<TransportInfo>> GetTrasportInfoByDateAndSpeed(string date, double speed)
        {
            if(DateTime.Now > DateTime.ParseExact(Environment.GetEnvironmentVariable("TIME START"), "HH:mm",null) 
                && DateTime.Now < DateTime.ParseExact(Environment.GetEnvironmentVariable("TIME END"), "HH:mm", null))
            {
                return _transportInfo.GetTrasportInfoByDateAndSpeed(date, speed);
            }

            return StatusCode(418);
        }

        [HttpPost]
        public ActionResult<TransportInfo> CreateTransportInfo([FromBody] TransportInfo transportInfo)
        {
            _transportInfo.AddTransportInfo(transportInfo);
            return Ok();
        }

    }
}
