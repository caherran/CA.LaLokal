using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Queries
{
    public class GetEstratoQuery : IRequest<ResponseBase<EstratoDto>>
    {
        public int Id { get; set; }
    }

    public class GetEstratoQueryHandler : IRequestHandler<GetEstratoQuery, ResponseBase<EstratoDto>>
    {
        private readonly IRepository<Estrato> _repository;
        private readonly IMapper _mapper;

        public GetEstratoQueryHandler(IRepository<Estrato> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EstratoDto>> Handle(GetEstratoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Estrato", request.Id);
            }

            var dto = _mapper.Map<EstratoDto>(entity);

            return Task.FromResult(new ResponseBase<EstratoDto>(dto));
        }
    }
}