using AutoMapper;
using AutoMapper.QueryableExtensions;
using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Queries
{
    public class GetEstadosUsuarioQuery : IRequest<ResponseBase<List<EstadoUsuarioDto>>>
    {
    }

    public class GetEstadosClienteQueryHandler : IRequestHandler<GetEstadosUsuarioQuery, ResponseBase<List<EstadoUsuarioDto>>>
    {
        private readonly IRepository<EstadoUsuario> _repository;
        private readonly IMapper _mapper;

        public GetEstadosClienteQueryHandler(IRepository<EstadoUsuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EstadoUsuarioDto>>> Handle(GetEstadosUsuarioQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EstadoUsuarioDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EstadoUsuarioDto>>(dto.ToList()));
        }
    }
}