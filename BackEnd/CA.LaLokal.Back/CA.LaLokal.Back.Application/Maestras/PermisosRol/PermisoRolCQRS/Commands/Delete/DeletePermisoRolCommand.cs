using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.PermisosRol;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Commands.Delete
{
    public class DeletePermisoRolCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeletePermisoRolCommandHandler : IRequestHandler<DeletePermisoRolCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PermisoRol> _repository;

        public DeletePermisoRolCommandHandler(IUnitOfWork unitOfWork, IRepository<PermisoRol> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeletePermisoRolCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("PermisoRol", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
