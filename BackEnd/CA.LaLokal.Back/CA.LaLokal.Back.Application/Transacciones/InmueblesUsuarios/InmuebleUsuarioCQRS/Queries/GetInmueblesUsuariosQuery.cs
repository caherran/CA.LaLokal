using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesUsuarios;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Queries
{
    public class GetInmueblesUsuariosQuery : IRequest<ResponseBase<List<InmuebleUsuarioDto>>>
    {
    }

    public class GetInmueblesUsuariosQueryHandler : IRequestHandler<GetInmueblesUsuariosQuery, ResponseBase<List<InmuebleUsuarioDto>>>
    {
        private readonly IRepository<InmuebleUsuario> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesUsuariosQueryHandler(IRepository<InmuebleUsuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleUsuarioDto>>> Handle(GetInmueblesUsuariosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleUsuarioDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleUsuarioDto>>(dto.ToList()));
        }
    }
}