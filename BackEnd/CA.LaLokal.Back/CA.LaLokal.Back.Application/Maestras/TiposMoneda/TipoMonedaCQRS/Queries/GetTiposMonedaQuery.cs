using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Queries
{
    public class GetTiposMonedaQuery : IRequest<ResponseBase<List<TipoMonedaDto>>>
    {
    }

    public class GetTiposMonedaQueryHandler : IRequestHandler<GetTiposMonedaQuery, ResponseBase<List<TipoMonedaDto>>>
    {
        private readonly IRepository<TipoMoneda> _repository;
        private readonly IMapper _mapper;

        public GetTiposMonedaQueryHandler(IRepository<TipoMoneda> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoMonedaDto>>> Handle(GetTiposMonedaQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoMonedaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoMonedaDto>>(dto.ToList()));
        }
    }
}