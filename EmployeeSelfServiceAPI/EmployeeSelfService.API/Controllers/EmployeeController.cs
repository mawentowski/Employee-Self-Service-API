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
        /// Deletes an employee.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public void Delete(int id) =>
            _employeeService.DeleteEntity(id);

        /// <summary>
        /// Gets employees.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Employee>> Get() =>
            Ok(_employeeService.GetEntities());

        /// <summary>
        /// Finds an employee by Id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Employee>> Find(int id) =>
            Ok(_employeeService.GetById(id));

        /// <summary>
        /// Creates an employee.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200)]
        public void Post([FromBody] Employee employee)
        {
            _employeeService.AddEntity(employee);
        }

        /// <summary>
        /// Updates an employee.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public void Put([FromBody] Employee employee) =>
            _employeeService.UpdateEntity(employee);
    }
}
