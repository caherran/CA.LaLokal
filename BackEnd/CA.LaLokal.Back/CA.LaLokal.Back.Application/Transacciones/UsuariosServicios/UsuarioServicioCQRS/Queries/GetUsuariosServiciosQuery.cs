using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosServicios;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosServicios.UsuarioServicioCQRS.Queries
{
    public class GetUsuariosServiciosQuery : IRequest<ResponseBase<List<UsuarioServicioDto>>>
    {
    }

    public class GetUsuariosServiciosQueryHandler : IRequestHandler<GetUsuariosServiciosQuery, ResponseBase<List<UsuarioServicioDto>>>
    {
        private readonly IRepository<UsuarioServicio> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosServiciosQueryHandler(IRepository<UsuarioServicio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioServicioDto>>> Handle(GetUsuariosServiciosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioServicioDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioServicioDto>>(dto.ToList()));
        }
    }
}