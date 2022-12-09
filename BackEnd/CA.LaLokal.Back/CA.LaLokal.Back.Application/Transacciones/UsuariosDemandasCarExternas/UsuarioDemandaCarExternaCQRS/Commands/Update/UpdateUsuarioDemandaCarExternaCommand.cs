using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarExternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarExternas.UsuarioDemandaCarExternaCQRS.Commands.Update
{
    public class UpdateUsuarioDemandaCarExternaCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioDemandaCarExterna>
    {
        public Guid Id { get; set; }
public Guid UsuarioDemandaId { get; set; }
public int CaracteristicaExternaId { get; set; }

    }

    public class UpdateUsuarioDemandaCarExternaCommandHandler : IRequestHandler<UpdateUsuarioDemandaCarExternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDemandaCarExterna> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioDemandaCarExternaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDemandaCarExterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioDemandaCarExternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDemandaCarExterna", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
