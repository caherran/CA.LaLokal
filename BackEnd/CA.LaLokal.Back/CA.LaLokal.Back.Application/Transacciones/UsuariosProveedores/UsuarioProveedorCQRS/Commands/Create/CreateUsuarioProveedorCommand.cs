using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosProveedores.UsuarioProveedorCQRS.Commands.Create
{
    public class CreateUsuarioProveedorCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioProveedor>
    {
        public Guid UsuarioId { get; set; }
public string Foto { get; set; }
public string Nombre { get; set; }
public int CiudadId { get; set; }
public string Descripcion { get; set; }
public string PaginaWeb { get; set; }
public string URLFacebook { get; set; }
public string URLInstagram { get; set; }
public int CategoriaId { get; set; }

    }

    public class CreateUsuarioProveedorCommandHandler : IRequestHandler<CreateUsuarioProveedorCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioProveedor> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioProveedorCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioProveedor> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioProveedorCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioProveedor>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
