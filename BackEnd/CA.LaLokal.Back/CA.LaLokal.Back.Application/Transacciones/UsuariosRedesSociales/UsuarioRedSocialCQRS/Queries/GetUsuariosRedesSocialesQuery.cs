using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosRedesSociales;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosRedesSociales.UsuarioRedSocialCQRS.Queries
{
    public class GetUsuariosRedesSocialesQuery : IRequest<ResponseBase<List<UsuarioRedSocialDto>>>
    {
    }

    public class GetUsuariosRedesSocialesQueryHandler : IRequestHandler<GetUsuariosRedesSocialesQuery, ResponseBase<List<UsuarioRedSocialDto>>>
    {
        private readonly IRepository<UsuarioRedSocial> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosRedesSocialesQueryHandler(IRepository<UsuarioRedSocial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioRedSocialDto>>> Handle(GetUsuariosRedesSocialesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioRedSocialDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioRedSocialDto>>(dto.ToList()));
        }
    }
}