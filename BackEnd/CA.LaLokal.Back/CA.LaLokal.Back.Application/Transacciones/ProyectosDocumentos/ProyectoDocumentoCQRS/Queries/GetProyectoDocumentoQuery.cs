using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosDocumentos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosDocumentos.ProyectoDocumentoCQRS.Queries
{
    public class GetProyectoDocumentoQuery : IRequest<ResponseBase<ProyectoDocumentoDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetProyectoDocumentoQueryHandler : IRequestHandler<GetProyectoDocumentoQuery, ResponseBase<ProyectoDocumentoDto>>
    {
        private readonly IRepository<ProyectoDocumento> _repository;
        private readonly IMapper _mapper;

        public GetProyectoDocumentoQueryHandler(IRepository<ProyectoDocumento> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<ProyectoDocumentoDto>> Handle(GetProyectoDocumentoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ProyectoDocumento", request.Id);
            }

            var dto = _mapper.Map<ProyectoDocumentoDto>(entity);

            return Task.FromResult(new ResponseBase<ProyectoDocumentoDto>(dto));
        }
    }
}