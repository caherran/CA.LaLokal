using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Proyectos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Proyectos.ProyectoCQRS.Queries
{
    public class GetProyectosQuery : IRequest<ResponseBase<List<ProyectoDto>>>
    {
    }

    public class GetProyectosQueryHandler : IRequestHandler<GetProyectosQuery, ResponseBase<List<ProyectoDto>>>
    {
        private readonly IRepository<Proyecto> _repository;
        private readonly IMapper _mapper;

        public GetProyectosQueryHandler(IRepository<Proyecto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<ProyectoDto>>> Handle(GetProyectosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<ProyectoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<ProyectoDto>>(dto.ToList()));
        }
    }
}