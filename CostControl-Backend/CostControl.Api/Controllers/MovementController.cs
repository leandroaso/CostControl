using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CostControl.Api.Controllers
{
    [ApiController]
    public class MovementController : ControllerBase
    {
        private IMovementService _service;

        public MovementController(IMovementService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/movements/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _service.Get(id);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("api/movements/{pageSize:int}/{pageNumber:int}")]
        public IEnumerable<Movement> GetAll(int pageSize, int pageNumber)
        {
            var movements = _service.GetAllWithPagination(pageSize, pageNumber);

            return movements;
        }

        [HttpPost]
        [Route("api/movements")]
        public IActionResult Save([FromBody]Movement movement)
        {
            var result = _service.Save(movement);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/movements")]
        public IActionResult Update([FromBody]Movement movement)
        {
            var result = _service.Update(movement);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/movements/{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _service.Remove(id);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }
    }
}