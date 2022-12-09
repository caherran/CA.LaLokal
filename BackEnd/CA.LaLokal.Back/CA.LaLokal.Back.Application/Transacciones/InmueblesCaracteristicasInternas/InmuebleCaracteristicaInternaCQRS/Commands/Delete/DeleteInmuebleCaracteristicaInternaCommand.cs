using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Commands.Delete
{
    public class DeleteInmuebleCaracteristicaInternaCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteInmuebleCaracteristicaInternaCommandHandler : IRequestHandler<DeleteInmuebleCaracteristicaInternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleCaracteristicaInterna> _repository;

        public DeleteInmuebleCaracteristicaInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleCaracteristicaInterna> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteInmuebleCaracteristicaInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleCaracteristicaInterna", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
