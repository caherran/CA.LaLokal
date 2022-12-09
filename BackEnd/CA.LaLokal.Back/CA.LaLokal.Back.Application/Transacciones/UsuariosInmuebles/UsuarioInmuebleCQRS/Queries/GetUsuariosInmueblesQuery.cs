using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosInmuebles;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosInmuebles.UsuarioInmuebleCQRS.Queries
{
    public class GetUsuariosInmueblesQuery : IRequest<ResponseBase<List<UsuarioInmuebleDto>>>
    {
    }

    public class GetUsuariosInmueblesQueryHandler : IRequestHandler<GetUsuariosInmueblesQuery, ResponseBase<List<UsuarioInmuebleDto>>>
    {
        private readonly IRepository<UsuarioInmueble> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosInmueblesQueryHandler(IRepository<UsuarioInmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioInmuebleDto>>> Handle(GetUsuariosInmueblesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioInmuebleDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioInmuebleDto>>(dto.ToList()));
        }
    }
}