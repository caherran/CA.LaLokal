using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Queries
{
    public class GetTiposNegocioQuery : IRequest<ResponseBase<List<TipoNegocioDto>>>
    {
    }

    public class GetTiposNegocioQueryHandler : IRequestHandler<GetTiposNegocioQuery, ResponseBase<List<TipoNegocioDto>>>
    {
        private readonly IRepository<TipoNegocio> _repository;
        private readonly IMapper _mapper;

        public GetTiposNegocioQueryHandler(IRepository<TipoNegocio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoNegocioDto>>> Handle(GetTiposNegocioQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoNegocioDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoNegocioDto>>(dto.ToList()));
        }
    }
}