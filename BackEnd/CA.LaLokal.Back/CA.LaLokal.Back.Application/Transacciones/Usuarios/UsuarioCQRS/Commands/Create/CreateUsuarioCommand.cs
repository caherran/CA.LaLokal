using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Commands.Create
{
    public class CreateUsuarioCommand : IRequest<ResponseBase<Guid>>, IMapFrom<Usuario>
    {
        public int TipoUsuarioId { get; set; }
public Guid UsuarioEncargadoId { get; set; }
public int EstadoUsuarioId { get; set; }
public string Nombres { get; set; }
public string ApellIdos { get; set; }
public int TipoPersonaId { get; set; }
public string CorreoElectronico { get; set; }
public string TelefonoFijo { get; set; }
public string TelefonoMovil { get; set; }
public DateTime FechaNacimiento { get; set; }
public int TipoIdentificacionId { get; set; }
public string NumeroIdentificacion { get; set; }
public int MedioCaptacionId { get; set; }
public string ReferidoPor { get; set; }
public string DatosAdicionales { get; set; }
public int CiudadId { get; set; }
public string Direccion { get; set; }
public string Observaciones { get; set; }
public string CopiaCedula { get; set; }
public string ContratoPrestacion { get; set; }
public string RUT { get; set; }
public string URLFoto { get; set; }

    }

    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<Usuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Usuario>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
