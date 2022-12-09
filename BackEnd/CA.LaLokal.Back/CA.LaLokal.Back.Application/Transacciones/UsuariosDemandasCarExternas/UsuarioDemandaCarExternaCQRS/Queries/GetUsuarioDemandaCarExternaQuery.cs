using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarExternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarExternas.UsuarioDemandaCarExternaCQRS.Queries
{
    public class GetUsuarioDemandaCarExternaQuery : IRequest<ResponseBase<UsuarioDemandaCarExternaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioDemandaCarExternaQueryHandler : IRequestHandler<GetUsuarioDemandaCarExternaQuery, ResponseBase<UsuarioDemandaCarExternaDto>>
    {
        private readonly IRepository<UsuarioDemandaCarExterna> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioDemandaCarExternaQueryHandler(IRepository<UsuarioDemandaCarExterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDemandaCarExternaDto>> Handle(GetUsuarioDemandaCarExternaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDemandaCarExterna", request.Id);
            }

            var dto = _mapper.Map<UsuarioDemandaCarExternaDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDemandaCarExternaDto>(dto));
        }
    }
}