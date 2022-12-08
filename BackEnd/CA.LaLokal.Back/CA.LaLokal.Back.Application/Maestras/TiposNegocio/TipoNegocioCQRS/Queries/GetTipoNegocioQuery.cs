using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Queries
{
    public class GetTipoNegocioQuery : IRequest<ResponseBase<TipoNegocioDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoNegocioQueryHandler : IRequestHandler<GetTipoNegocioQuery, ResponseBase<TipoNegocioDto>>
    {
        private readonly IRepository<TipoNegocio> _repository;
        private readonly IMapper _mapper;

        public GetTipoNegocioQueryHandler(IRepository<TipoNegocio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoNegocioDto>> Handle(GetTipoNegocioQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoNegocio", request.Id);
            }

            var dto = _mapper.Map<TipoNegocioDto>(entity);

            return Task.FromResult(new ResponseBase<TipoNegocioDto>(dto));
        }
    }
}