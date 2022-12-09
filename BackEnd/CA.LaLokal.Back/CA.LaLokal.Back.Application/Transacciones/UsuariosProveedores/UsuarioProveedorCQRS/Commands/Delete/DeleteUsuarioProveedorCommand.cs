using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosProveedores.UsuarioProveedorCQRS.Commands.Delete
{
    public class DeleteUsuarioProveedorCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUsuarioProveedorCommandHandler : IRequestHandler<DeleteUsuarioProveedorCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioProveedor> _repository;

        public DeleteUsuarioProveedorCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioProveedor> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteUsuarioProveedorCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioProveedor", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
