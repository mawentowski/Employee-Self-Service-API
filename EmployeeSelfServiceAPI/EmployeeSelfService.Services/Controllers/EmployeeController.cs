﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeSelfService.Models;


namespace EmployeeSelfService.API.Controllers
{
    [ApiController]
    [Route("[employee]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<Employee> _logger;

        public EmployeeController(ILogger<Employee> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
