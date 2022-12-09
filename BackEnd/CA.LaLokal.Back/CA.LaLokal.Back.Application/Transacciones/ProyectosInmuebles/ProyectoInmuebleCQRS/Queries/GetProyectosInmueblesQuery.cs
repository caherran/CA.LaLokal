using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInmuebles;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInmuebles.ProyectoInmuebleCQRS.Queries
{
    public class GetProyectosInmueblesQuery : IRequest<ResponseBase<List<ProyectoInmuebleDto>>>
    {
    }

    public class GetProyectosInmueblesQueryHandler : IRequestHandler<GetProyectosInmueblesQuery, ResponseBase<List<ProyectoInmuebleDto>>>
    {
        private readonly IRepository<ProyectoInmueble> _repository;
        private readonly IMapper _mapper;

        public GetProyectosInmueblesQueryHandler(IRepository<ProyectoInmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<ProyectoInmuebleDto>>> Handle(GetProyectosInmueblesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<ProyectoInmuebleDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<ProyectoInmuebleDto>>(dto.ToList()));
        }
    }
}