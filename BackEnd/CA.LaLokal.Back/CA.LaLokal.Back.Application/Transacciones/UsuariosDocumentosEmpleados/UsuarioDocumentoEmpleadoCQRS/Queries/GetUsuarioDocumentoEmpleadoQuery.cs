using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosEmpleados;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosEmpleados.UsuarioDocumentoEmpleadoCQRS.Queries
{
    public class GetUsuarioDocumentoEmpleadoQuery : IRequest<ResponseBase<UsuarioDocumentoEmpleadoDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioDocumentoEmpleadoQueryHandler : IRequestHandler<GetUsuarioDocumentoEmpleadoQuery, ResponseBase<UsuarioDocumentoEmpleadoDto>>
    {
        private readonly IRepository<UsuarioDocumentoEmpleado> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioDocumentoEmpleadoQueryHandler(IRepository<UsuarioDocumentoEmpleado> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDocumentoEmpleadoDto>> Handle(GetUsuarioDocumentoEmpleadoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoEmpleado", request.Id);
            }

            var dto = _mapper.Map<UsuarioDocumentoEmpleadoDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDocumentoEmpleadoDto>(dto));
        }
    }
}