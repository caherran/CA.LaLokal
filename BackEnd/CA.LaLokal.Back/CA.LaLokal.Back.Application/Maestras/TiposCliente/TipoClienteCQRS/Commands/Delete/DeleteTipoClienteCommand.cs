using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Commands.Delete
{
    public class DeleteTipoClienteCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipoClienteCommandHandler : IRequestHandler<DeleteTipoClienteCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoCliente> _repository;

        public DeleteTipoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoCliente> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteTipoClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoCliente", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
