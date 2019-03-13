using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CostControl.Api.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/employees/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _service.Get(id);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("api/employees")]
        public IEnumerable<Employee> GetAll()
        {
            var employees = _service.GetAll();

            return employees;
        }

        [HttpPost]
        [Route("api/employees")]
        public IActionResult Save([FromBody]Employee employee)
        {
            var result = _service.Save(employee);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/employees")]
        public IActionResult Update([FromBody]Employee employee)
        {
            var result = _service.Update(employee);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/employees/{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _service.Remove(id);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }
    }
}