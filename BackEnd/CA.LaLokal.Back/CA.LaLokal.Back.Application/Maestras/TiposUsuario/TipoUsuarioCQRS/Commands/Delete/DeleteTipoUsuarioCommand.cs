using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Commands.Delete
{
    public class DeleteTipoUsuarioCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipoUsuarioCommandHandler : IRequestHandler<DeleteTipoUsuarioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoUsuario> _repository;

        public DeleteTipoUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoUsuario> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteTipoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoUsuario", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
