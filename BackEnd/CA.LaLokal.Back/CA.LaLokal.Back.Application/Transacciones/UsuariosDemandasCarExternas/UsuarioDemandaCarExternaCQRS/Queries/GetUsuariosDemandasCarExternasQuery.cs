using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarExternas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarExternas.UsuarioDemandaCarExternaCQRS.Queries
{
    public class GetUsuariosDemandasCarExternasQuery : IRequest<ResponseBase<List<UsuarioDemandaCarExternaDto>>>
    {
    }

    public class GetUsuariosDemandasCarExternasQueryHandler : IRequestHandler<GetUsuariosDemandasCarExternasQuery, ResponseBase<List<UsuarioDemandaCarExternaDto>>>
    {
        private readonly IRepository<UsuarioDemandaCarExterna> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosDemandasCarExternasQueryHandler(IRepository<UsuarioDemandaCarExterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDemandaCarExternaDto>>> Handle(GetUsuariosDemandasCarExternasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDemandaCarExternaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDemandaCarExternaDto>>(dto.ToList()));
        }
    }
}