using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Commands.Create
{
    public class CreateUsuarioDemandaCarInternaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioDemandaCarInterna>
    {
        public Guid UsuarioDemandaId { get; set; }
public int CaracteristicaInternaId { get; set; }

    }

    public class CreateUsuarioDemandaCarInternaCommandHandler : IRequestHandler<CreateUsuarioDemandaCarInternaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDemandaCarInterna> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioDemandaCarInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDemandaCarInterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioDemandaCarInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioDemandaCarInterna>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
