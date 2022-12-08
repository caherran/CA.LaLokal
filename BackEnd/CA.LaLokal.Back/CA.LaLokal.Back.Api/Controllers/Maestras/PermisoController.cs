using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Api.Utils.Controller;
using CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Commands.Create;
using CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Commands.Delete;
using CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Commands.Update;
using CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Queries;

namespace CA.LaLokal.Back.Api.Controllers.Maestras
{
    [AllowAnonymous]
    public class PermisoController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PermisoDto>> Get(int id)
        {
            var result = await Mediator.Send(new GetPermisoQuery() { Id = id });
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
        public async Task<ActionResult<List<PermisoDto>>> Get()
        {
            var result = await Mediator.Send(new GetPermisosQuery());
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
        public async Task<ActionResult<int>> Create(CreatePermisoCommand command)
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
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdatePermisoCommand command)
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
            var result = await Mediator.Send(new DeletePermisoCommand() { Id = id });
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
