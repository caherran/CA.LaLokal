using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Queries
{
    public class GetUsuariosDemandasQuery : IRequest<ResponseBase<List<UsuarioDemandaDto>>>
    {
    }

    public class GetUsuariosDemandasQueryHandler : IRequestHandler<GetUsuariosDemandasQuery, ResponseBase<List<UsuarioDemandaDto>>>
    {
        private readonly IRepository<UsuarioDemanda> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosDemandasQueryHandler(IRepository<UsuarioDemanda> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDemandaDto>>> Handle(GetUsuariosDemandasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDemandaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDemandaDto>>(dto.ToList()));
        }
    }
}