using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Queries
{
    public class GetZonaBarrioQuery : IRequest<ResponseBase<ZonaBarrioDto>>
    {
        public int Id { get; set; }
    }

    public class GetZonaBarrioQueryHandler : IRequestHandler<GetZonaBarrioQuery, ResponseBase<ZonaBarrioDto>>
    {
        private readonly IRepository<ZonaBarrio> _repository;
        private readonly IMapper _mapper;

        public GetZonaBarrioQueryHandler(IRepository<ZonaBarrio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<ZonaBarrioDto>> Handle(GetZonaBarrioQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ZonaBarrio", request.Id);
            }

            var dto = _mapper.Map<ZonaBarrioDto>(entity);

            return Task.FromResult(new ResponseBase<ZonaBarrioDto>(dto));
        }
    }
}