using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposPersona;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPersona.TipoPersonaCQRS.Queries
{
    public class GetTiposPersonaQuery : IRequest<ResponseBase<List<TipoPersonaDto>>>
    {
    }

    public class GetTiposPersonaQueryHandler : IRequestHandler<GetTiposPersonaQuery, ResponseBase<List<TipoPersonaDto>>>
    {
        private readonly IRepository<TipoPersona> _repository;
        private readonly IMapper _mapper;

        public GetTiposPersonaQueryHandler(IRepository<TipoPersona> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoPersonaDto>>> Handle(GetTiposPersonaQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoPersonaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoPersonaDto>>(dto.ToList()));
        }
    }
}