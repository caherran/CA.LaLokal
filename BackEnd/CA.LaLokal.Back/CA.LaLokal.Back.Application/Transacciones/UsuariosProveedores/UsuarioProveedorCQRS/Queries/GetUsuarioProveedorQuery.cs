using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosProveedores;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosProveedores.UsuarioProveedorCQRS.Queries
{
    public class GetUsuarioProveedorQuery : IRequest<ResponseBase<UsuarioProveedorDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioProveedorQueryHandler : IRequestHandler<GetUsuarioProveedorQuery, ResponseBase<UsuarioProveedorDto>>
    {
        private readonly IRepository<UsuarioProveedor> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioProveedorQueryHandler(IRepository<UsuarioProveedor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioProveedorDto>> Handle(GetUsuarioProveedorQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioProveedor", request.Id);
            }

            var dto = _mapper.Map<UsuarioProveedorDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioProveedorDto>(dto));
        }
    }
}