using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Queries
{
    public class GetEstadoPublicacionQuery : IRequest<ResponseBase<EstadoPublicacionDto>>
    {
        public int Id { get; set; }
    }

    public class GetEstadoPublicacionQueryHandler : IRequestHandler<GetEstadoPublicacionQuery, ResponseBase<EstadoPublicacionDto>>
    {
        private readonly IRepository<EstadoPublicacion> _repository;
        private readonly IMapper _mapper;

        public GetEstadoPublicacionQueryHandler(IRepository<EstadoPublicacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EstadoPublicacionDto>> Handle(GetEstadoPublicacionQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoPublicacion", request.Id);
            }

            var dto = _mapper.Map<EstadoPublicacionDto>(entity);

            return Task.FromResult(new ResponseBase<EstadoPublicacionDto>(dto));
        }
    }
}