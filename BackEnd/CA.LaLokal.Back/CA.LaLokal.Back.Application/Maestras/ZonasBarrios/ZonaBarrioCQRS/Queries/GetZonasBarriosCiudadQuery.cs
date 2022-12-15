using AutoMapper;
using CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries
{
    public class GetZonasBarriosCiudadQuery : IRequest<ResponseBase<List<ZonaBarrioDto>>>
    {
        public int CiudadId { get; set; }
    }

    public class GetZonasBarriosCiudadQueryHandler : IRequestHandler<GetZonasBarriosCiudadQuery, ResponseBase<List<ZonaBarrioDto>>>
    {
        private readonly IRepository<ZonaBarrio> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Ciudad> _repositoryCiudad;

        public GetZonasBarriosCiudadQueryHandler(IRepository<ZonaBarrio> repository, IMapper mapper, IRepository<Ciudad> repositoryCiudad)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryCiudad = repositoryCiudad;
        }

        public Task<ResponseBase<List<ZonaBarrioDto>>> Handle(GetZonasBarriosCiudadQuery request, CancellationToken cancellationToken)
        {
            var query = from barrio in _repository.TableNoTracking
                        join ciudad in _repositoryCiudad.TableNoTracking on barrio.CiudadId equals ciudad.Id
                        where ciudad.Id == request.CiudadId
                        select new ZonaBarrioDto()
                        {
                            Id = barrio.Id,
                            Codigo = barrio.Codigo,
                            Nombre = barrio.Nombre,
                            Ciudad = new CiudadDto()
                            {
                                Id = ciudad.Id,
                                Codigo = ciudad.Codigo,
                                Nombre = ciudad.Nombre
                            }
                        };

            return Task.FromResult(new ResponseBase<List<ZonaBarrioDto>>(query.ToList()));
        }
    }
}