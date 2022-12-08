using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Tiempos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Tiempos.TiempoCQRS.Queries
{
    public class GetTiempoQuery : IRequest<ResponseBase<TiempoDto>>
    {
        public int Id { get; set; }
    }

    public class GetTiempoQueryHandler : IRequestHandler<GetTiempoQuery, ResponseBase<TiempoDto>>
    {
        private readonly IRepository<Tiempo> _repository;
        private readonly IMapper _mapper;

        public GetTiempoQueryHandler(IRepository<Tiempo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TiempoDto>> Handle(GetTiempoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Tiempo", request.Id);
            }

            var dto = _mapper.Map<TiempoDto>(entity);

            return Task.FromResult(new ResponseBase<TiempoDto>(dto));
        }
    }
}