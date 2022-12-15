using CA.Api.Utils.Controller;
using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Commands.Create;
using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Commands.Delete;
using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Commands.Update;
using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Api.Controllers.Maestras
{
    [AllowAnonymous]
    public class CiudadController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var result = await Mediator.Send(new GetCiudadQuery() { Id = id });
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
        public async Task<ActionResult<List<CiudadDto>>> Get()
        {
            var result = await Mediator.Send(new GetCiudadesQuery());
            if (result.IsValidResponse)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet("GetCiudadesDepartamento/{departamentoId:int}")]
        public async Task<ActionResult<List<CiudadDto>>> GetCiudadesDepartamento(int departamentoId)
        {
            GetCiudadesDepartamentoQuery query = new GetCiudadesDepartamentoQuery
            {
                DepartamentoId = departamentoId
            };

            var result = await Mediator.Send(query);
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
        public async Task<ActionResult<int>> Create(CreateCiudadCommand command)
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
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateCiudadCommand command)
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
            var result = await Mediator.Send(new DeleteCiudadCommand() { Id = id });
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
