using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Queries
{
    public class GetEstadosFisicoPropiedadQuery : IRequest<ResponseBase<List<EstadoFisicoPropiedadDto>>>
    {
    }

    public class GetEstadosFisicoPropiedadQueryHandler : IRequestHandler<GetEstadosFisicoPropiedadQuery, ResponseBase<List<EstadoFisicoPropiedadDto>>>
    {
        private readonly IRepository<EstadoFisicoPropiedad> _repository;
        private readonly IMapper _mapper;

        public GetEstadosFisicoPropiedadQueryHandler(IRepository<EstadoFisicoPropiedad> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EstadoFisicoPropiedadDto>>> Handle(GetEstadosFisicoPropiedadQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EstadoFisicoPropiedadDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EstadoFisicoPropiedadDto>>(dto.ToList()));
        }
    }
}