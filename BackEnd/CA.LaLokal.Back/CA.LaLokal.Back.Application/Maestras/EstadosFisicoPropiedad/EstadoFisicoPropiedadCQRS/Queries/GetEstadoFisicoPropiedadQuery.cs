using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Queries
{
    public class GetEstadoFisicoPropiedadQuery : IRequest<ResponseBase<EstadoFisicoPropiedadDto>>
    {
        public int Id { get; set; }
    }

    public class GetEstadoFisicoPropiedadQueryHandler : IRequestHandler<GetEstadoFisicoPropiedadQuery, ResponseBase<EstadoFisicoPropiedadDto>>
    {
        private readonly IRepository<EstadoFisicoPropiedad> _repository;
        private readonly IMapper _mapper;

        public GetEstadoFisicoPropiedadQueryHandler(IRepository<EstadoFisicoPropiedad> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EstadoFisicoPropiedadDto>> Handle(GetEstadoFisicoPropiedadQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoFisicoPropiedad", request.Id);
            }

            var dto = _mapper.Map<EstadoFisicoPropiedadDto>(entity);

            return Task.FromResult(new ResponseBase<EstadoFisicoPropiedadDto>(dto));
        }
    }
}