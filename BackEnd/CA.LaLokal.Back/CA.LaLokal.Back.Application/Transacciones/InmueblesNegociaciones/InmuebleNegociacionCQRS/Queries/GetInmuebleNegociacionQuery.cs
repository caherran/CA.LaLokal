using AutoMapper;
using CA.Domain.Auditable.Exceptions;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesNegociaciones.InmuebleNegociacionCQRS.Queries
{
    public class GetInmuebleNegociacionQuery : IRequest<ResponseBase<InmuebleNegociacionDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleNegociacionQueryHandler : IRequestHandler<GetInmuebleNegociacionQuery, ResponseBase<InmuebleNegociacionDto>>
    {
        private readonly IRepository<InmuebleNegociacion> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleNegociacionQueryHandler(IRepository<InmuebleNegociacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleNegociacionDto>> Handle(GetInmuebleNegociacionQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleNegociacion", request.Id);
            }

            var dto = _mapper.Map<InmuebleNegociacionDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleNegociacionDto>(dto));
        }
    }
}