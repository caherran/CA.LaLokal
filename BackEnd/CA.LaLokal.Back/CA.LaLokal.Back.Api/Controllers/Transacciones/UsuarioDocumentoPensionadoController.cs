using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Api.Utils.Controller;
using CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Commands.Create;
using CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Commands.Delete;
using CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Commands.Update;
using CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Queries;

namespace CA.LaLokal.Back.Api.Controllers.Transacciones
{
    [AllowAnonymous]
    public class UsuarioDocumentoPensionadoController : ApiControllerBase
    {
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<UsuarioDocumentoPensionadoDto>> Get(Guid id)
        {
            var result = await Mediator.Send(new GetUsuarioDocumentoPensionadoQuery() { Id = id });
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
        public async Task<ActionResult<List<UsuarioDocumentoPensionadoDto>>> Get()
        {
            var result = await Mediator.Send(new GetUsuariosDocumentosPensionadosQuery());
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
        public async Task<ActionResult<Guid>> Create(CreateUsuarioDocumentoPensionadoCommand command)
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
        public async Task<ActionResult<bool>> Update(Guid id, [FromBody] UpdateUsuarioDocumentoPensionadoCommand command)
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
            var result = await Mediator.Send(new DeleteUsuarioDocumentoPensionadoCommand() { Id = id });
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
