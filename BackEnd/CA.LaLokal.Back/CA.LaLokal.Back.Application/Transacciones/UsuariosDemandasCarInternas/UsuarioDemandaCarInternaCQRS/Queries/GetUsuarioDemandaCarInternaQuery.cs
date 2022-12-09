using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Queries
{
    public class GetUsuarioDemandaCarInternaQuery : IRequest<ResponseBase<UsuarioDemandaCarInternaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioDemandaCarInternaQueryHandler : IRequestHandler<GetUsuarioDemandaCarInternaQuery, ResponseBase<UsuarioDemandaCarInternaDto>>
    {
        private readonly IRepository<UsuarioDemandaCarInterna> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioDemandaCarInternaQueryHandler(IRepository<UsuarioDemandaCarInterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDemandaCarInternaDto>> Handle(GetUsuarioDemandaCarInternaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDemandaCarInterna", request.Id);
            }

            var dto = _mapper.Map<UsuarioDemandaCarInternaDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDemandaCarInternaDto>(dto));
        }
    }
}