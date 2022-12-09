using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosExperienciasLaborales.UsuarioExperienciaLaboralCQRS.Commands.Create
{
    public class CreateUsuarioExperienciaLaboralCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioExperienciaLaboral>
    {
        public Guid UsuarioId { get; set; }
public string NombreEmpresa { get; set; }
public string Cargo { get; set; }
public string Direccion { get; set; }
public bool TrabajaActualmente { get; set; }
public DateTime FechaInicio { get; set; }
public DateTime FechaFinalizacion { get; set; }

    }

    public class CreateUsuarioExperienciaLaboralCommandHandler : IRequestHandler<CreateUsuarioExperienciaLaboralCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioExperienciaLaboral> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioExperienciaLaboralCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioExperienciaLaboral> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioExperienciaLaboralCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioExperienciaLaboral>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
