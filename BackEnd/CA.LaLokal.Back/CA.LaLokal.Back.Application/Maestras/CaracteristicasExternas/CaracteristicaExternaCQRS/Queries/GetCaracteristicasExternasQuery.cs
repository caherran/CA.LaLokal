using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Queries
{
    public class GetCaracteristicasExternasQuery : IRequest<ResponseBase<List<CaracteristicaExternaDto>>>
    {
    }

    public class GetCaracteristicasExternasQueryHandler : IRequestHandler<GetCaracteristicasExternasQuery, ResponseBase<List<CaracteristicaExternaDto>>>
    {
        private readonly IRepository<CaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public GetCaracteristicasExternasQueryHandler(IRepository<CaracteristicaExterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<CaracteristicaExternaDto>>> Handle(GetCaracteristicasExternasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<CaracteristicaExternaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<CaracteristicaExternaDto>>(dto.ToList()));
        }
    }
}