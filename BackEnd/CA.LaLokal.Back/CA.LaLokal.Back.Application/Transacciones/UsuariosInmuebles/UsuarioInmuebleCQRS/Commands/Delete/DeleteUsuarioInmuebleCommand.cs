using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosInmuebles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosInmuebles.UsuarioInmuebleCQRS.Commands.Delete
{
    public class DeleteUsuarioInmuebleCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUsuarioInmuebleCommandHandler : IRequestHandler<DeleteUsuarioInmuebleCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioInmueble> _repository;

        public DeleteUsuarioInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioInmueble> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteUsuarioInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioInmueble", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
