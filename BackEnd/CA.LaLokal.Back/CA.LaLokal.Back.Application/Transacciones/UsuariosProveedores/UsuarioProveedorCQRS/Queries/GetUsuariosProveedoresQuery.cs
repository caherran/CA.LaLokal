using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosProveedores.UsuarioProveedorCQRS.Queries
{
    public class GetUsuariosProveedoresQuery : IRequest<ResponseBase<List<UsuarioProveedorDto>>>
    {
    }

    public class GetUsuariosProveedoresQueryHandler : IRequestHandler<GetUsuariosProveedoresQuery, ResponseBase<List<UsuarioProveedorDto>>>
    {
        private readonly IRepository<UsuarioProveedor> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosProveedoresQueryHandler(IRepository<UsuarioProveedor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioProveedorDto>>> Handle(GetUsuariosProveedoresQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioProveedorDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioProveedorDto>>(dto.ToList()));
        }
    }
}