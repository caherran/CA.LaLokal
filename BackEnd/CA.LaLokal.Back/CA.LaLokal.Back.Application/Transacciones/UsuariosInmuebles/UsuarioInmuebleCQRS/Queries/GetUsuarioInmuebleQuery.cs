using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosInmuebles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosInmuebles.UsuarioInmuebleCQRS.Queries
{
    public class GetUsuarioInmuebleQuery : IRequest<ResponseBase<UsuarioInmuebleDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioInmuebleQueryHandler : IRequestHandler<GetUsuarioInmuebleQuery, ResponseBase<UsuarioInmuebleDto>>
    {
        private readonly IRepository<UsuarioInmueble> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioInmuebleQueryHandler(IRepository<UsuarioInmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioInmuebleDto>> Handle(GetUsuarioInmuebleQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioInmueble", request.Id);
            }

            var dto = _mapper.Map<UsuarioInmuebleDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioInmuebleDto>(dto));
        }
    }
}