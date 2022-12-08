using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Queries
{
    public class GetCaracteristicasInternasQuery : IRequest<ResponseBase<List<CaracteristicaInternaDto>>>
    {
    }

    public class GetCaracteristicasInternasQueryHandler : IRequestHandler<GetCaracteristicasInternasQuery, ResponseBase<List<CaracteristicaInternaDto>>>
    {
        private readonly IRepository<CaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public GetCaracteristicasInternasQueryHandler(IRepository<CaracteristicaInterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<CaracteristicaInternaDto>>> Handle(GetCaracteristicasInternasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<CaracteristicaInternaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<CaracteristicaInternaDto>>(dto.ToList()));
        }
    }
}