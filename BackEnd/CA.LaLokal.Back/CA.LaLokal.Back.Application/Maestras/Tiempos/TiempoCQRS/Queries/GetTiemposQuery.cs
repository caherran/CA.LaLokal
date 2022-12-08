using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Tiempos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Tiempos.TiempoCQRS.Queries
{
    public class GetTiemposQuery : IRequest<ResponseBase<List<TiempoDto>>>
    {
    }

    public class GetTiemposQueryHandler : IRequestHandler<GetTiemposQuery, ResponseBase<List<TiempoDto>>>
    {
        private readonly IRepository<Tiempo> _repository;
        private readonly IMapper _mapper;

        public GetTiemposQueryHandler(IRepository<Tiempo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TiempoDto>>> Handle(GetTiemposQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TiempoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TiempoDto>>(dto.ToList()));
        }
    }
}