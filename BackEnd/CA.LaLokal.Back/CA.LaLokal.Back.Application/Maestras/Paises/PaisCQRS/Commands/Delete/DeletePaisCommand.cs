using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Commands.Delete
{
    public class DeletePaisCommand : IRequest<ResponseBase<bool>>
    {
        public int Id { get; set; }
    }

    public class DeletePaisCommandHandler : IRequestHandler<DeletePaisCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Pais> _repository;

        public DeletePaisCommandHandler(IUnitOfWork unitOfWork, IRepository<Pais> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeletePaisCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Pais", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
