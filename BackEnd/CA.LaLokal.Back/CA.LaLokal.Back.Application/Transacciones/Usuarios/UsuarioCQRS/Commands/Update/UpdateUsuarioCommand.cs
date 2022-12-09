using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Commands.Update
{
    public class UpdateUsuarioCommand : IRequest<ResponseBase<bool>>, IMapFrom<Usuario>
    {
        public Guid Id { get; set; }
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

    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<Usuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Usuario", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
