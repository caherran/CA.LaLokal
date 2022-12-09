using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Queries
{
    public class GetUsuariosDemandasCarInternasQuery : IRequest<ResponseBase<List<UsuarioDemandaCarInternaDto>>>
    {
    }

    public class GetUsuariosDemandasCarInternasQueryHandler : IRequestHandler<GetUsuariosDemandasCarInternasQuery, ResponseBase<List<UsuarioDemandaCarInternaDto>>>
    {
        private readonly IRepository<UsuarioDemandaCarInterna> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosDemandasCarInternasQueryHandler(IRepository<UsuarioDemandaCarInterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDemandaCarInternaDto>>> Handle(GetUsuariosDemandasCarInternasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDemandaCarInternaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDemandaCarInternaDto>>(dto.ToList()));
        }
    }
}