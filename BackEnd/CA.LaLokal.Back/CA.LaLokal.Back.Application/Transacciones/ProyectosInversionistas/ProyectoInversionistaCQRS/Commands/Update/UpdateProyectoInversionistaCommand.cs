using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInversionistas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInversionistas.ProyectoInversionistaCQRS.Commands.Update
{
    public class UpdateProyectoInversionistaCommand : IRequest<ResponseBase<bool>>, IMapFrom<ProyectoInversionista>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public Guid UsuarioInversionistaId { get; set; }

    }

    public class UpdateProyectoInversionistaCommandHandler : IRequestHandler<UpdateProyectoInversionistaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProyectoInversionista> _repository;
        private readonly IMapper _mapper;

        public UpdateProyectoInversionistaCommandHandler(IUnitOfWork unitOfWork, IRepository<ProyectoInversionista> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateProyectoInversionistaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ProyectoInversionista", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
