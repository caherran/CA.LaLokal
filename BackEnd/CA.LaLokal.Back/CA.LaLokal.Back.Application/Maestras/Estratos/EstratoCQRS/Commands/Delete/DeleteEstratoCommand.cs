using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Commands.Delete
{
    public class DeleteEstratoCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeleteEstratoCommandHandler : IRequestHandler<DeleteEstratoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Estrato> _repository;

        public DeleteEstratoCommandHandler(IUnitOfWork unitOfWork, IRepository<Estrato> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteEstratoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Estrato", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
