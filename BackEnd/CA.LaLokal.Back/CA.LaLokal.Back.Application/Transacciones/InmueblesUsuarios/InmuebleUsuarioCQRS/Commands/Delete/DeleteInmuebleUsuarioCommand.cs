using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesUsuarios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Commands.Delete
{
    public class DeleteInmuebleUsuarioCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteInmuebleUsuarioCommandHandler : IRequestHandler<DeleteInmuebleUsuarioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleUsuario> _repository;

        public DeleteInmuebleUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleUsuario> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteInmuebleUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleUsuario", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
