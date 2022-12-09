using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandasCarInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandasCarInternas.UsuarioDemandaCarInternaCQRS.Commands.Delete
{
    public class DeleteUsuarioDemandaCarInternaCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUsuarioDemandaCarInternaCommandHandler : IRequestHandler<DeleteUsuarioDemandaCarInternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDemandaCarInterna> _repository;

        public DeleteUsuarioDemandaCarInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDemandaCarInterna> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteUsuarioDemandaCarInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDemandaCarInterna", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
