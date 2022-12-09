using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Proyectos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Proyectos.ProyectoCQRS.Queries
{
    public class GetProyectoQuery : IRequest<ResponseBase<ProyectoDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetProyectoQueryHandler : IRequestHandler<GetProyectoQuery, ResponseBase<ProyectoDto>>
    {
        private readonly IRepository<Proyecto> _repository;
        private readonly IMapper _mapper;

        public GetProyectoQueryHandler(IRepository<Proyecto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<ProyectoDto>> Handle(GetProyectoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Proyecto", request.Id);
            }

            var dto = _mapper.Map<ProyectoDto>(entity);

            return Task.FromResult(new ResponseBase<ProyectoDto>(dto));
        }
    }
}