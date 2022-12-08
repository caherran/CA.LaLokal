using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Pisos.PisoCQRS.Queries
{
    public class GetPisosQuery : IRequest<ResponseBase<List<PisoDto>>>
    {
    }

    public class GetPisosQueryHandler : IRequestHandler<GetPisosQuery, ResponseBase<List<PisoDto>>>
    {
        private readonly IRepository<Piso> _repository;
        private readonly IMapper _mapper;

        public GetPisosQueryHandler(IRepository<Piso> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<PisoDto>>> Handle(GetPisosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<PisoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<PisoDto>>(dto.ToList()));
        }
    }
}