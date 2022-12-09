using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Usuarios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Usuarios.UsuarioCQRS.Queries
{
    public class GetUsuarioQuery : IRequest<ResponseBase<UsuarioDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, ResponseBase<UsuarioDto>>
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioQueryHandler(IRepository<Usuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDto>> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Usuario", request.Id);
            }

            var dto = _mapper.Map<UsuarioDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDto>(dto));
        }
    }
}