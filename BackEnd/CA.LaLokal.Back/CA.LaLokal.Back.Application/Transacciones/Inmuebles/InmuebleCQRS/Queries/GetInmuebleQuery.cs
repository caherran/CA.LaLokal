using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries
{
    public class GetInmuebleQuery : IRequest<ResponseBase<InmuebleDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleQueryHandler : IRequestHandler<GetInmuebleQuery, ResponseBase<InmuebleDto>>
    {
        private readonly IRepository<Inmueble> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleQueryHandler(IRepository<Inmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleDto>> Handle(GetInmuebleQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Inmueble", request.Id);
            }

            var dto = _mapper.Map<InmuebleDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleDto>(dto));
        }
    }
}