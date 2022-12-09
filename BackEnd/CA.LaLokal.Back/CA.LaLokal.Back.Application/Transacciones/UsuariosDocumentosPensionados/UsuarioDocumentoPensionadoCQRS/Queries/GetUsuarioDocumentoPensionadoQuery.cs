using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosPensionados;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Queries
{
    public class GetUsuarioDocumentoPensionadoQuery : IRequest<ResponseBase<UsuarioDocumentoPensionadoDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioDocumentoPensionadoQueryHandler : IRequestHandler<GetUsuarioDocumentoPensionadoQuery, ResponseBase<UsuarioDocumentoPensionadoDto>>
    {
        private readonly IRepository<UsuarioDocumentoPensionado> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioDocumentoPensionadoQueryHandler(IRepository<UsuarioDocumentoPensionado> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDocumentoPensionadoDto>> Handle(GetUsuarioDocumentoPensionadoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoPensionado", request.Id);
            }

            var dto = _mapper.Map<UsuarioDocumentoPensionadoDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDocumentoPensionadoDto>(dto));
        }
    }
}