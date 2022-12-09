using CA.Domain.Auditable.Exceptions;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesNegociaciones.InmuebleNegociacionCQRS.Commands.Delete
{
    public class DeleteInmuebleNegociacionCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteInmuebleNegociacionCommandHandler : IRequestHandler<DeleteInmuebleNegociacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleNegociacion> _repository;

        public DeleteInmuebleNegociacionCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleNegociacion> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteInmuebleNegociacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleNegociacion", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
