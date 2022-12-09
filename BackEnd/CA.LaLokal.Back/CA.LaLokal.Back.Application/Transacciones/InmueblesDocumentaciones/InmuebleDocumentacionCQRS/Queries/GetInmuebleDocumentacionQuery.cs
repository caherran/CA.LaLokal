using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesDocumentaciones;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesDocumentaciones.InmuebleDocumentacionCQRS.Queries
{
    public class GetInmuebleDocumentacionQuery : IRequest<ResponseBase<InmuebleDocumentacionDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleDocumentacionQueryHandler : IRequestHandler<GetInmuebleDocumentacionQuery, ResponseBase<InmuebleDocumentacionDto>>
    {
        private readonly IRepository<InmuebleDocumentacion> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleDocumentacionQueryHandler(IRepository<InmuebleDocumentacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleDocumentacionDto>> Handle(GetInmuebleDocumentacionQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleDocumentacion", request.Id);
            }

            var dto = _mapper.Map<InmuebleDocumentacionDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleDocumentacionDto>(dto));
        }
    }
}