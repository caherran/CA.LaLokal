using CA.Domain.Auditable.Exceptions;
using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Commands.Delete
{
    public class DeleteEstadoUsuarioCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteEstadoClienteCommandHandler : IRequestHandler<DeleteEstadoUsuarioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoUsuario> _repository;

        public DeleteEstadoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoUsuario> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteEstadoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoCliente", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
