using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CostControl.Api.Controllers
{
    [Authorize("Bearer")]
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
        public IActionResult GetAll(int pageSize, int pageNumber)
        {
            var result = _service.GetAllWithPagination(pageSize, pageNumber);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
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