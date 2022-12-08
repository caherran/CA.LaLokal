using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosProyecto.EstadoProyectoCQRS.Queries
{
    public class GetEstadosProyectoQuery : IRequest<ResponseBase<List<EstadoProyectoDto>>>
    {
    }

    public class GetEstadosProyectoQueryHandler : IRequestHandler<GetEstadosProyectoQuery, ResponseBase<List<EstadoProyectoDto>>>
    {
        private readonly IRepository<EstadoProyecto> _repository;
        private readonly IMapper _mapper;

        public GetEstadosProyectoQueryHandler(IRepository<EstadoProyecto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EstadoProyectoDto>>> Handle(GetEstadosProyectoQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EstadoProyectoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EstadoProyectoDto>>(dto.ToList()));
        }
    }
}