using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasGeografias;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasGeografias.ZonaGeograficaCQRS.Queries
{
    public class GetZonasGeografiasQuery : IRequest<ResponseBase<List<ZonaGeograficaDto>>>
    {
    }

    public class GetZonasGeografiasQueryHandler : IRequestHandler<GetZonasGeografiasQuery, ResponseBase<List<ZonaGeograficaDto>>>
    {
        private readonly IRepository<ZonaGeografica> _repository;
        private readonly IMapper _mapper;

        public GetZonasGeografiasQueryHandler(IRepository<ZonaGeografica> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<ZonaGeograficaDto>>> Handle(GetZonasGeografiasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<ZonaGeograficaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<ZonaGeograficaDto>>(dto.ToList()));
        }
    }
}