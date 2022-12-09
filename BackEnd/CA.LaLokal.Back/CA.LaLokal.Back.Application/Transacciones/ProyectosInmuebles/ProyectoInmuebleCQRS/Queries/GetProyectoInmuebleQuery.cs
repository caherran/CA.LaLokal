using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInmuebles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInmuebles.ProyectoInmuebleCQRS.Queries
{
    public class GetProyectoInmuebleQuery : IRequest<ResponseBase<ProyectoInmuebleDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetProyectoInmuebleQueryHandler : IRequestHandler<GetProyectoInmuebleQuery, ResponseBase<ProyectoInmuebleDto>>
    {
        private readonly IRepository<ProyectoInmueble> _repository;
        private readonly IMapper _mapper;

        public GetProyectoInmuebleQueryHandler(IRepository<ProyectoInmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<ProyectoInmuebleDto>> Handle(GetProyectoInmuebleQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ProyectoInmueble", request.Id);
            }

            var dto = _mapper.Map<ProyectoInmuebleDto>(entity);

            return Task.FromResult(new ResponseBase<ProyectoInmuebleDto>(dto));
        }
    }
}