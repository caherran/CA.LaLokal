using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarExternas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarExternas.UsuarioDemandaCarExternaCQRS.Commands.Create
{
    public class CreateUsuarioDemandaCarExternaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioDemandaCarExterna>
    {
        public Guid UsuarioDemandaId { get; set; }
public int CaracteristicaExternaId { get; set; }

    }

    public class CreateUsuarioDemandaCarExternaCommandHandler : IRequestHandler<CreateUsuarioDemandaCarExternaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDemandaCarExterna> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioDemandaCarExternaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDemandaCarExterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioDemandaCarExternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioDemandaCarExterna>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
