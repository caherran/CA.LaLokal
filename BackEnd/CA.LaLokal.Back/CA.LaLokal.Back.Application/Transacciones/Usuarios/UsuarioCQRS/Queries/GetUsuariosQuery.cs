using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries
{
    public class GetUsuariosQuery : IRequest<ResponseBase<List<UsuarioDto>>>
    {
    }

    public class GetUsuariosQueryHandler : IRequestHandler<GetUsuariosQuery, ResponseBase<List<UsuarioDto>>>
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosQueryHandler(IRepository<Usuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDto>>> Handle(GetUsuariosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDto>>(dto.ToList()));
        }
    }
}