using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeSelfService.Models;
using EmployeeSelfService.Services.Implementations;

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
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Employee>> Find(int id) =>
            Ok(_employeeService.GetById(id));

        /// <summary>
        /// Creates an employee.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201)]
        public CreatedAtActionResult Post([FromBody] Employee employee)
        {
            Employee newEmployee = _employeeService.AddEntity(employee);
            return CreatedAtAction(nameof(Find), new { id = newEmployee.Id }, newEmployee);
        }

        /// <summary>
        /// Updates an employee.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put([FromBody] Employee employee)
        {
            _employeeService.UpdateEntity(employee);
            return Ok();
        }
    }
}
