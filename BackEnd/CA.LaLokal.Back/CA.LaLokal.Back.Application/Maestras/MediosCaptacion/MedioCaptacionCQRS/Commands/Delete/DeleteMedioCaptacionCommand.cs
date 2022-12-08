using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Commands.Delete
{
    public class DeleteMedioCaptacionCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteMedioCaptacionCommandHandler : IRequestHandler<DeleteMedioCaptacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<MedioCaptacion> _repository;

        public DeleteMedioCaptacionCommandHandler(IUnitOfWork unitOfWork, IRepository<MedioCaptacion> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteMedioCaptacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("MedioCaptacion", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
