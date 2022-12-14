using CA.Api.Utils.Controller;
using CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Commands.Create;
using CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Commands.Delete;
using CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Commands.Update;
using CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Api.Controllers.Maestras
{
    [AllowAnonymous]
    public class DepartamentoController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var result = await Mediator.Send(new GetDepartamentoQuery() { Id = id });
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
        public async Task<ActionResult<List<DepartamentoDto>>> Get()
        {
            var result = await Mediator.Send(new GetDepartamentosQuery());
            if (result.IsValidResponse)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet("GetDepartamentosPais/{paisId:int}")]
        public async Task<ActionResult<List<DepartamentoDto>>> GetDepartamentosPais(int paisId)
        {
            GetDepartamentosPaisQuery query = new GetDepartamentosPaisQuery
            {
                PaisId = paisId
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
        public async Task<ActionResult<int>> Create(CreateDepartamentoCommand command)
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
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateDepartamentoCommand command)
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
            var result = await Mediator.Send(new DeleteDepartamentoCommand() { Id = id });
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
