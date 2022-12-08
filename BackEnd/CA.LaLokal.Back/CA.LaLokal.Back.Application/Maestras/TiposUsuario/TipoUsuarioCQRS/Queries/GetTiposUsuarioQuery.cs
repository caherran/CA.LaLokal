using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Queries
{
    public class GetTiposUsuarioQuery : IRequest<ResponseBase<List<TipoUsuarioDto>>>
    {
    }

    public class GetTiposUsuarioQueryHandler : IRequestHandler<GetTiposUsuarioQuery, ResponseBase<List<TipoUsuarioDto>>>
    {
        private readonly IRepository<TipoUsuario> _repository;
        private readonly IMapper _mapper;

        public GetTiposUsuarioQueryHandler(IRepository<TipoUsuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoUsuarioDto>>> Handle(GetTiposUsuarioQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoUsuarioDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoUsuarioDto>>(dto.ToList()));
        }
    }
}