using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Queries
{
    public class GetTipoMonedaQuery : IRequest<ResponseBase<TipoMonedaDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoMonedaQueryHandler : IRequestHandler<GetTipoMonedaQuery, ResponseBase<TipoMonedaDto>>
    {
        private readonly IRepository<TipoMoneda> _repository;
        private readonly IMapper _mapper;

        public GetTipoMonedaQueryHandler(IRepository<TipoMoneda> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoMonedaDto>> Handle(GetTipoMonedaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoMoneda", request.Id);
            }

            var dto = _mapper.Map<TipoMonedaDto>(entity);

            return Task.FromResult(new ResponseBase<TipoMonedaDto>(dto));
        }
    }
}