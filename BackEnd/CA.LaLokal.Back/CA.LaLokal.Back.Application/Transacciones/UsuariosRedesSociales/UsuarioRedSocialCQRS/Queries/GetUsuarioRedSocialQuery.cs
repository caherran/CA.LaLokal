using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosRedesSociales;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosRedesSociales.UsuarioRedSocialCQRS.Queries
{
    public class GetUsuarioRedSocialQuery : IRequest<ResponseBase<UsuarioRedSocialDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioRedSocialQueryHandler : IRequestHandler<GetUsuarioRedSocialQuery, ResponseBase<UsuarioRedSocialDto>>
    {
        private readonly IRepository<UsuarioRedSocial> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioRedSocialQueryHandler(IRepository<UsuarioRedSocial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioRedSocialDto>> Handle(GetUsuarioRedSocialQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioRedSocial", request.Id);
            }

            var dto = _mapper.Map<UsuarioRedSocialDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioRedSocialDto>(dto));
        }
    }
}