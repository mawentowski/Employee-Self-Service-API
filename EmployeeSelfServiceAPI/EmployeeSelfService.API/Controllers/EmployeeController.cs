using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeSelfService.Models;
using EmployeeSelfService.Services.Implementations;
using System.Net;


namespace EmployeeSelfService.API.Controllers
{
    /// <summary>
    /// Employee endpoint.
    /// </summary>
    [ApiConventionType(typeof(DefaultApiConventions))]
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

        /// <summary>
        /// Gets employees.
        /// </summary>
        [HttpGet]
        public IEnumerable<Employee> Get() =>
            _employeeService.GetEntities();


        /// <summary>
        /// Updates an employee.
        /// </summary>
        [HttpPut]
        public void Put([FromBody] Employee employee)
        {
            _employeeService.UpdateEntity(employee);
        }
    }
}
