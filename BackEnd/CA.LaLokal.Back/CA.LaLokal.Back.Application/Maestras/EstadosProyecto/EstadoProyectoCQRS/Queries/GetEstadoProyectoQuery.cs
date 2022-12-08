using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosProyecto.EstadoProyectoCQRS.Queries
{
    public class GetEstadoProyectoQuery : IRequest<ResponseBase<EstadoProyectoDto>>
    {
        public int Id { get; set; }
    }

    public class GetEstadoProyectoQueryHandler : IRequestHandler<GetEstadoProyectoQuery, ResponseBase<EstadoProyectoDto>>
    {
        private readonly IRepository<EstadoProyecto> _repository;
        private readonly IMapper _mapper;

        public GetEstadoProyectoQueryHandler(IRepository<EstadoProyecto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EstadoProyectoDto>> Handle(GetEstadoProyectoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoProyecto", request.Id);
            }

            var dto = _mapper.Map<EstadoProyectoDto>(entity);

            return Task.FromResult(new ResponseBase<EstadoProyectoDto>(dto));
        }
    }
}