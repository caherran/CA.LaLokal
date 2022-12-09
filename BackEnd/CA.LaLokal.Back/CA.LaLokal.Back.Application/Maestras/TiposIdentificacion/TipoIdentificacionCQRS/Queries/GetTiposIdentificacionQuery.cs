using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Queries
{
    public class GetTiposIdentificacionQuery : IRequest<ResponseBase<List<TipoIdentificacionDto>>>
    {
    }

    public class GetTiposIdentificacionQueryHandler : IRequestHandler<GetTiposIdentificacionQuery, ResponseBase<List<TipoIdentificacionDto>>>
    {
        private readonly IRepository<TipoIdentificacion> _repository;
        private readonly IMapper _mapper;

        public GetTiposIdentificacionQueryHandler(IRepository<TipoIdentificacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoIdentificacionDto>>> Handle(GetTiposIdentificacionQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoIdentificacionDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoIdentificacionDto>>(dto.ToList()));
        }
    }
}