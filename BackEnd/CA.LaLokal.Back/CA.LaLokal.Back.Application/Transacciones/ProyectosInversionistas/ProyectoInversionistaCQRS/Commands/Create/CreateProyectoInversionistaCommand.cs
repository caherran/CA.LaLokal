using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInversionistas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInversionistas.ProyectoInversionistaCQRS.Commands.Create
{
    public class CreateProyectoInversionistaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<ProyectoInversionista>
    {
        public Guid InmuebleId { get; set; }
public Guid UsuarioInversionistaId { get; set; }

    }

    public class CreateProyectoInversionistaCommandHandler : IRequestHandler<CreateProyectoInversionistaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProyectoInversionista> _repository;
        private readonly IMapper _mapper;

        public CreateProyectoInversionistaCommandHandler(IUnitOfWork unitOfWork, IRepository<ProyectoInversionista> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateProyectoInversionistaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProyectoInversionista>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
