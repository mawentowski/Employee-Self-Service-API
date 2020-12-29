using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeSelfService.Models;
using EmployeeSelfService.Services.Implementations;

namespace EmployeeSelfService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<Employee> _logger;

        public EmployeeController(EmployeeService employeeService,ILogger<Employee> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetEntities();

        }
    }
}
