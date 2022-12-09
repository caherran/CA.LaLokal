using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Commands.Update
{
    public class UpdateUsuarioDemandaCarInternaCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioDemandaCarInterna>
    {
        public Guid Id { get; set; }
public Guid UsuarioDemandaId { get; set; }
public int CaracteristicaInternaId { get; set; }

    }

    public class UpdateUsuarioDemandaCarInternaCommandHandler : IRequestHandler<UpdateUsuarioDemandaCarInternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDemandaCarInterna> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioDemandaCarInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDemandaCarInterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioDemandaCarInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDemandaCarInterna", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
