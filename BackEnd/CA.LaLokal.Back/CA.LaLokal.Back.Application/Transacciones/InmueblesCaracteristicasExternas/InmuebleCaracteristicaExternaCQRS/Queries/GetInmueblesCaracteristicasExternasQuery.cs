using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasExternas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasExternas.InmuebleCaracteristicaExternaCQRS.Queries
{
    public class GetInmueblesCaracteristicasExternasQuery : IRequest<ResponseBase<List<InmuebleCaracteristicaExternaDto>>>
    {
    }

    public class GetInmueblesCaracteristicasExternasQueryHandler : IRequestHandler<GetInmueblesCaracteristicasExternasQuery, ResponseBase<List<InmuebleCaracteristicaExternaDto>>>
    {
        private readonly IRepository<InmuebleCaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesCaracteristicasExternasQueryHandler(IRepository<InmuebleCaracteristicaExterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleCaracteristicaExternaDto>>> Handle(GetInmueblesCaracteristicasExternasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleCaracteristicaExternaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleCaracteristicaExternaDto>>(dto.ToList()));
        }
    }
}