using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Queries
{
    public class GetInmuebleCaracteristicaInternaQuery : IRequest<ResponseBase<InmuebleCaracteristicaInternaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleCaracteristicaInternaQueryHandler : IRequestHandler<GetInmuebleCaracteristicaInternaQuery, ResponseBase<InmuebleCaracteristicaInternaDto>>
    {
        private readonly IRepository<InmuebleCaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleCaracteristicaInternaQueryHandler(IRepository<InmuebleCaracteristicaInterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleCaracteristicaInternaDto>> Handle(GetInmuebleCaracteristicaInternaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleCaracteristicaInterna", request.Id);
            }

            var dto = _mapper.Map<InmuebleCaracteristicaInternaDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleCaracteristicaInternaDto>(dto));
        }
    }
}