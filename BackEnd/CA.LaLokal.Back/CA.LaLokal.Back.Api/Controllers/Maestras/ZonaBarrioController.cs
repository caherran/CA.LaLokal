using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Api.Utils.Controller;
using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Commands.Create;
using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Commands.Delete;
using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Commands.Update;
using CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries;

namespace CA.LaLokal.Back.Api.Controllers.Maestras
{
    [AllowAnonymous]
    public class ZonaBarrioController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ZonaBarrioDto>> Get(int id)
        {
            var result = await Mediator.Send(new GetZonaBarrioQuery() { Id = id });
            if (result.IsValidResponse)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ZonaBarrioDto>>> Get()
        {
            var result = await Mediator.Send(new GetZonasBarriosQuery());
            if (result.IsValidResponse)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateZonaBarrioCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.IsValidResponse)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateZonaBarrioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await Mediator.Send(command);
            if (result.IsValidResponse)
            {
                return Ok(result.Result);
            }
            else
            {
                var problem = new ProblemDetails()
                {
                    Title = "Bad Request",
                    Status = 400,
                    Detail = "Request can not be processed with the input data provided",
                };

                foreach (var error in result.Errors)
                {
                    problem.Extensions.Add(new KeyValuePair<string, object>(error.Key, error.Value));
                }

                return ValidationProblem(new ValidationProblemDetails(result.Errors));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteZonaBarrioCommand() { Id = id });
            if (result.IsValidResponse)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
