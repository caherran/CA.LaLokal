using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosServicios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosServicios.UsuarioServicioCQRS.Queries
{
    public class GetUsuarioServicioQuery : IRequest<ResponseBase<UsuarioServicioDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioServicioQueryHandler : IRequestHandler<GetUsuarioServicioQuery, ResponseBase<UsuarioServicioDto>>
    {
        private readonly IRepository<UsuarioServicio> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioServicioQueryHandler(IRepository<UsuarioServicio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioServicioDto>> Handle(GetUsuarioServicioQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioServicio", request.Id);
            }

            var dto = _mapper.Map<UsuarioServicioDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioServicioDto>(dto));
        }
    }
}