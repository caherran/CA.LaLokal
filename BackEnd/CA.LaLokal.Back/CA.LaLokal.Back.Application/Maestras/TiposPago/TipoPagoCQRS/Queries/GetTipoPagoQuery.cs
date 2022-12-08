using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposPago;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPago.TipoPagoCQRS.Queries
{
    public class GetTipoPagoQuery : IRequest<ResponseBase<TipoPagoDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoPagoQueryHandler : IRequestHandler<GetTipoPagoQuery, ResponseBase<TipoPagoDto>>
    {
        private readonly IRepository<TipoPago> _repository;
        private readonly IMapper _mapper;

        public GetTipoPagoQueryHandler(IRepository<TipoPago> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoPagoDto>> Handle(GetTipoPagoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoPago", request.Id);
            }

            var dto = _mapper.Map<TipoPagoDto>(entity);

            return Task.FromResult(new ResponseBase<TipoPagoDto>(dto));
        }
    }
}