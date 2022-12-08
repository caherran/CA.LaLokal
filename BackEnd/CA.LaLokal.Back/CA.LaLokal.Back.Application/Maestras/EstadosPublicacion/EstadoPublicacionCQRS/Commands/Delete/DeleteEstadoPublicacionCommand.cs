using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Commands.Delete
{
    public class DeleteEstadoPublicacionCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteEstadoPublicacionCommandHandler : IRequestHandler<DeleteEstadoPublicacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoPublicacion> _repository;

        public DeleteEstadoPublicacionCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoPublicacion> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteEstadoPublicacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoPublicacion", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
