using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostControl.Domain.Entities;
using CostControl.Domain.Interfaces.Services;
using CostControl.Shared.Enums;
using CostControl.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.Api.Controllers
{
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private IDepartamentService _service;

        public DepartamentController(IDepartamentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/departaments/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _service.Get(id);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("api/departaments/{pageSize:int}/{pageNumber:int}")]
        public IEnumerable<Departament> GetAll(int pageSize, int pageNumber)
        {
            var departaments = _service.GetAll(pageSize, pageNumber);

            return departaments;
        }

        [HttpPost]
        [Route("api/departaments")]
        public IActionResult Save([FromBody]Departament departament)
        {
            var result = _service.Save(departament);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/departaments")]
        public IActionResult Update([FromBody]Departament departament)
        {
            var result = _service.Update(departament);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/departaments/{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _service.Remove(id);

            if (result.Status == EResultStatus.Failure)
                return BadRequest(result);

            return Ok(result);
        }
    }
}