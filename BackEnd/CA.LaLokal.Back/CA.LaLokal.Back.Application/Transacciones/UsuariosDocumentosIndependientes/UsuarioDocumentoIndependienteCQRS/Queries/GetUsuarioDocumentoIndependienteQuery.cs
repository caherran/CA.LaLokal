using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosIndependientes;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosIndependientes.UsuarioDocumentoIndependienteCQRS.Queries
{
    public class GetUsuarioDocumentoIndependienteQuery : IRequest<ResponseBase<UsuarioDocumentoIndependienteDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioDocumentoIndependienteQueryHandler : IRequestHandler<GetUsuarioDocumentoIndependienteQuery, ResponseBase<UsuarioDocumentoIndependienteDto>>
    {
        private readonly IRepository<UsuarioDocumentoIndependiente> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioDocumentoIndependienteQueryHandler(IRepository<UsuarioDocumentoIndependiente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDocumentoIndependienteDto>> Handle(GetUsuarioDocumentoIndependienteQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoIndependiente", request.Id);
            }

            var dto = _mapper.Map<UsuarioDocumentoIndependienteDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDocumentoIndependienteDto>(dto));
        }
    }
}