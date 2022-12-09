using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Commands.Delete
{
    public class DeleteInmuebleMultimediaImagenCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteInmuebleMultimediaImagenCommandHandler : IRequestHandler<DeleteInmuebleMultimediaImagenCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleMultimediaImagen> _repository;

        public DeleteInmuebleMultimediaImagenCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleMultimediaImagen> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteInmuebleMultimediaImagenCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleMultimediaImagen", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
