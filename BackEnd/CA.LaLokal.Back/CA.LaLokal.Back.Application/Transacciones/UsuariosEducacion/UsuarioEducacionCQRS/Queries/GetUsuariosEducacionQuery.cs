using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosEducacion;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosEducacion.UsuarioEducacionCQRS.Queries
{
    public class GetUsuariosEducacionQuery : IRequest<ResponseBase<List<UsuarioEducacionDto>>>
    {
    }

    public class GetUsuariosEducacionQueryHandler : IRequestHandler<GetUsuariosEducacionQuery, ResponseBase<List<UsuarioEducacionDto>>>
    {
        private readonly IRepository<UsuarioEducacion> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosEducacionQueryHandler(IRepository<UsuarioEducacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioEducacionDto>>> Handle(GetUsuariosEducacionQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioEducacionDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioEducacionDto>>(dto.ToList()));
        }
    }
}