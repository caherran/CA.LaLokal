using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasGeografias;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasGeografias.ZonaGeograficaCQRS.Queries
{
    public class GetZonaGeograficaQuery : IRequest<ResponseBase<ZonaGeograficaDto>>
    {
        public int Id { get; set; }
    }

    public class GetZonaGeograficaQueryHandler : IRequestHandler<GetZonaGeograficaQuery, ResponseBase<ZonaGeograficaDto>>
    {
        private readonly IRepository<ZonaGeografica> _repository;
        private readonly IMapper _mapper;

        public GetZonaGeograficaQueryHandler(IRepository<ZonaGeografica> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<ZonaGeograficaDto>> Handle(GetZonaGeograficaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ZonaGeografica", request.Id);
            }

            var dto = _mapper.Map<ZonaGeograficaDto>(entity);

            return Task.FromResult(new ResponseBase<ZonaGeograficaDto>(dto));
        }
    }
}