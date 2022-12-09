using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCompartir;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCompartir.InmuebleCompartirCQRS.Queries
{
    public class GetInmuebleCompartirQuery : IRequest<ResponseBase<InmuebleCompartirDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleCompartirQueryHandler : IRequestHandler<GetInmuebleCompartirQuery, ResponseBase<InmuebleCompartirDto>>
    {
        private readonly IRepository<InmuebleCompartir> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleCompartirQueryHandler(IRepository<InmuebleCompartir> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleCompartirDto>> Handle(GetInmuebleCompartirQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleCompartir", request.Id);
            }

            var dto = _mapper.Map<InmuebleCompartirDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleCompartirDto>(dto));
        }
    }
}