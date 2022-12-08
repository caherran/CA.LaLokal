using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Commands.Delete
{
    public class DeleteCaracteristicaExternaCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteCaracteristicaExternaCommandHandler : IRequestHandler<DeleteCaracteristicaExternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CaracteristicaExterna> _repository;

        public DeleteCaracteristicaExternaCommandHandler(IUnitOfWork unitOfWork, IRepository<CaracteristicaExterna> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteCaracteristicaExternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("CaracteristicaExterna", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
