using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposPersona;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPersona.TipoPersonaCQRS.Queries
{
    public class GetTipoPersonaQuery : IRequest<ResponseBase<TipoPersonaDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoPersonaQueryHandler : IRequestHandler<GetTipoPersonaQuery, ResponseBase<TipoPersonaDto>>
    {
        private readonly IRepository<TipoPersona> _repository;
        private readonly IMapper _mapper;

        public GetTipoPersonaQueryHandler(IRepository<TipoPersona> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoPersonaDto>> Handle(GetTipoPersonaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoPersona", request.Id);
            }

            var dto = _mapper.Map<TipoPersonaDto>(entity);

            return Task.FromResult(new ResponseBase<TipoPersonaDto>(dto));
        }
    }
}