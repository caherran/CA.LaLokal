using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesUsuarios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Queries
{
    public class GetInmuebleUsuarioQuery : IRequest<ResponseBase<InmuebleUsuarioDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleUsuarioQueryHandler : IRequestHandler<GetInmuebleUsuarioQuery, ResponseBase<InmuebleUsuarioDto>>
    {
        private readonly IRepository<InmuebleUsuario> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleUsuarioQueryHandler(IRepository<InmuebleUsuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleUsuarioDto>> Handle(GetInmuebleUsuarioQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleUsuario", request.Id);
            }

            var dto = _mapper.Map<InmuebleUsuarioDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleUsuarioDto>(dto));
        }
    }
}