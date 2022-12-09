using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Api.Utils.Controller;
using CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Commands.Create;
using CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Commands.Delete;
using CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Commands.Update;
using CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Queries;

namespace CA.LaLokal.Back.Api.Controllers.Transacciones
{
    [AllowAnonymous]
    public class InmuebleMultimediaImagenController : ApiControllerBase
    {
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<InmuebleMultimediaImagenDto>> Get(Guid id)
        {
            var result = await Mediator.Send(new GetInmuebleMultimediaImagenQuery() { Id = id });
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
        public async Task<ActionResult<List<InmuebleMultimediaImagenDto>>> Get()
        {
            var result = await Mediator.Send(new GetInmueblesMultimediaImagenesQuery());
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
        public async Task<ActionResult<Guid>> Create(CreateInmuebleMultimediaImagenCommand command)
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

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<bool>> Update(Guid id, [FromBody] UpdateInmuebleMultimediaImagenCommand command)
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

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteInmuebleMultimediaImagenCommand() { Id = id });
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
