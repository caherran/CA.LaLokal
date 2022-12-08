using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosCartera;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCartera.EstadoCarteraCQRS.Queries
{
    public class GetEstadoCarteraQuery : IRequest<ResponseBase<EstadoCarteraDto>>
    {
        public int Id { get; set; }
    }

    public class GetEstadoCarteraQueryHandler : IRequestHandler<GetEstadoCarteraQuery, ResponseBase<EstadoCarteraDto>>
    {
        private readonly IRepository<EstadoCartera> _repository;
        private readonly IMapper _mapper;

        public GetEstadoCarteraQueryHandler(IRepository<EstadoCartera> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EstadoCarteraDto>> Handle(GetEstadoCarteraQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoCartera", request.Id);
            }

            var dto = _mapper.Map<EstadoCarteraDto>(entity);

            return Task.FromResult(new ResponseBase<EstadoCarteraDto>(dto));
        }
    }
}