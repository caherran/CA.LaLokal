using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosProveedores.UsuarioProveedorCQRS.Commands.Update
{
    public class UpdateUsuarioProveedorCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioProveedor>
    {
        public Guid Id { get; set; }
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

    public class UpdateUsuarioProveedorCommandHandler : IRequestHandler<UpdateUsuarioProveedorCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioProveedor> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioProveedorCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioProveedor> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioProveedorCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioProveedor", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
