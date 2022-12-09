using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosExperienciasLaborales.UsuarioExperienciaLaboralCQRS.Commands.Delete
{
    public class DeleteUsuarioExperienciaLaboralCommand : IRequest<ResponseBase<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUsuarioExperienciaLaboralCommandHandler : IRequestHandler<DeleteUsuarioExperienciaLaboralCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioExperienciaLaboral> _repository;

        public DeleteUsuarioExperienciaLaboralCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioExperienciaLaboral> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ResponseBase<bool>> Handle(DeleteUsuarioExperienciaLaboralCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioExperienciaLaboral", request.Id);
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
