using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries
{
    public class GetZonasBarriosQuery : IRequest<ResponseBase<List<ZonaBarrioDto>>>
    {
    }

    public class GetZonasBarriosQueryHandler : IRequestHandler<GetZonasBarriosQuery, ResponseBase<List<ZonaBarrioDto>>>
    {
        private readonly IRepository<ZonaBarrio> _repository;
        private readonly IMapper _mapper;

        public GetZonasBarriosQueryHandler(IRepository<ZonaBarrio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<ZonaBarrioDto>>> Handle(GetZonasBarriosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<ZonaBarrioDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<ZonaBarrioDto>>(dto.ToList()));
        }
    }
}