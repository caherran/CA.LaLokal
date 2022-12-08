using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Queries
{
    public class GetEstadosPublicacionQuery : IRequest<ResponseBase<List<EstadoPublicacionDto>>>
    {
    }

    public class GetEstadosPublicacionQueryHandler : IRequestHandler<GetEstadosPublicacionQuery, ResponseBase<List<EstadoPublicacionDto>>>
    {
        private readonly IRepository<EstadoPublicacion> _repository;
        private readonly IMapper _mapper;

        public GetEstadosPublicacionQueryHandler(IRepository<EstadoPublicacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EstadoPublicacionDto>>> Handle(GetEstadosPublicacionQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EstadoPublicacionDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EstadoPublicacionDto>>(dto.ToList()));
        }
    }
}