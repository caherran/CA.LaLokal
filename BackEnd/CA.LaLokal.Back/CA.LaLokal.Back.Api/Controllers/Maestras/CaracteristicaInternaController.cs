using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Api.Utils.Controller;
using CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Commands.Create;
using CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Commands.Delete;
using CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Commands.Update;
using CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Queries;

namespace CA.LaLokal.Back.Api.Controllers.Maestras
{
    [AllowAnonymous]
    public class CaracteristicaInternaController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CaracteristicaInternaDto>> Get(int id)
        {
            var result = await Mediator.Send(new GetCaracteristicaInternaQuery() { Id = id });
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
        public async Task<ActionResult<List<CaracteristicaInternaDto>>> Get()
        {
            var result = await Mediator.Send(new GetCaracteristicasInternasQuery());
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
        public async Task<ActionResult<int>> Create(CreateCaracteristicaInternaCommand command)
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
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateCaracteristicaInternaCommand command)
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
            var result = await Mediator.Send(new DeleteCaracteristicaInternaCommand() { Id = id });
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
