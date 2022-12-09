using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasExternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasExternas.InmuebleCaracteristicaExternaCQRS.Queries
{
    public class GetInmuebleCaracteristicaExternaQuery : IRequest<ResponseBase<InmuebleCaracteristicaExternaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleCaracteristicaExternaQueryHandler : IRequestHandler<GetInmuebleCaracteristicaExternaQuery, ResponseBase<InmuebleCaracteristicaExternaDto>>
    {
        private readonly IRepository<InmuebleCaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleCaracteristicaExternaQueryHandler(IRepository<InmuebleCaracteristicaExterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleCaracteristicaExternaDto>> Handle(GetInmuebleCaracteristicaExternaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleCaracteristicaExterna", request.Id);
            }

            var dto = _mapper.Map<InmuebleCaracteristicaExternaDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleCaracteristicaExternaDto>(dto));
        }
    }
}