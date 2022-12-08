using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Queries
{
    public class GetTiposInmuebleQuery : IRequest<ResponseBase<List<TipoInmuebleDto>>>
    {
    }

    public class GetTiposInmuebleQueryHandler : IRequestHandler<GetTiposInmuebleQuery, ResponseBase<List<TipoInmuebleDto>>>
    {
        private readonly IRepository<TipoInmueble> _repository;
        private readonly IMapper _mapper;

        public GetTiposInmuebleQueryHandler(IRepository<TipoInmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoInmuebleDto>>> Handle(GetTiposInmuebleQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoInmuebleDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoInmuebleDto>>(dto.ToList()));
        }
    }
}