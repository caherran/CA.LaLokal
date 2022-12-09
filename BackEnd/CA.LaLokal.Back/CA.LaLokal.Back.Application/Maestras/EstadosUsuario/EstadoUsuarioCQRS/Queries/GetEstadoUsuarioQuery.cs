using AutoMapper;
using CA.Domain.Auditable.Exceptions;
using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Queries
{
    public class GetEstadoUsuarioQuery : IRequest<ResponseBase<EstadoUsuarioDto>>
    {
        public int Id { get; set; }
    }

    public class GetEstadoClienteQueryHandler : IRequestHandler<GetEstadoUsuarioQuery, ResponseBase<EstadoUsuarioDto>>
    {
        private readonly IRepository<EstadoUsuario> _repository;
        private readonly IMapper _mapper;

        public GetEstadoClienteQueryHandler(IRepository<EstadoUsuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EstadoUsuarioDto>> Handle(GetEstadoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoCliente", request.Id);
            }

            var dto = _mapper.Map<EstadoUsuarioDto>(entity);

            return Task.FromResult(new ResponseBase<EstadoUsuarioDto>(dto));
        }
    }
}