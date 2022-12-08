using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposPago;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPago.TipoPagoCQRS.Queries
{
    public class GetTiposPagoQuery : IRequest<ResponseBase<List<TipoPagoDto>>>
    {
    }

    public class GetTiposPagoQueryHandler : IRequestHandler<GetTiposPagoQuery, ResponseBase<List<TipoPagoDto>>>
    {
        private readonly IRepository<TipoPago> _repository;
        private readonly IMapper _mapper;

        public GetTiposPagoQueryHandler(IRepository<TipoPago> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoPagoDto>>> Handle(GetTiposPagoQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoPagoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoPagoDto>>(dto.ToList()));
        }
    }
}