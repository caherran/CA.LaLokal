using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Queries
{
    public class GetInmueblesCaracteristicasInternasQuery : IRequest<ResponseBase<List<InmuebleCaracteristicaInternaDto>>>
    {
    }

    public class GetInmueblesCaracteristicasInternasQueryHandler : IRequestHandler<GetInmueblesCaracteristicasInternasQuery, ResponseBase<List<InmuebleCaracteristicaInternaDto>>>
    {
        private readonly IRepository<InmuebleCaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesCaracteristicasInternasQueryHandler(IRepository<InmuebleCaracteristicaInterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleCaracteristicaInternaDto>>> Handle(GetInmueblesCaracteristicasInternasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleCaracteristicaInternaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleCaracteristicaInternaDto>>(dto.ToList()));
        }
    }
}