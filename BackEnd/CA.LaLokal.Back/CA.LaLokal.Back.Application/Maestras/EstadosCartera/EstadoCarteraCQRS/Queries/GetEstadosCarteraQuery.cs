using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosCartera;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCartera.EstadoCarteraCQRS.Queries
{
    public class GetEstadosCarteraQuery : IRequest<ResponseBase<List<EstadoCarteraDto>>>
    {
    }

    public class GetEstadosCarteraQueryHandler : IRequestHandler<GetEstadosCarteraQuery, ResponseBase<List<EstadoCarteraDto>>>
    {
        private readonly IRepository<EstadoCartera> _repository;
        private readonly IMapper _mapper;

        public GetEstadosCarteraQueryHandler(IRepository<EstadoCartera> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EstadoCarteraDto>>> Handle(GetEstadosCarteraQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EstadoCarteraDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EstadoCarteraDto>>(dto.ToList()));
        }
    }
}