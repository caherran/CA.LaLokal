using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Commands.Delete
{
    public class DeleteEstadoFisicoPropiedadCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteEstadoFisicoPropiedadCommandHandler : IRequestHandler<DeleteEstadoFisicoPropiedadCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoFisicoPropiedad> _repository;

        public DeleteEstadoFisicoPropiedadCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoFisicoPropiedad> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteEstadoFisicoPropiedadCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoFisicoPropiedad", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
