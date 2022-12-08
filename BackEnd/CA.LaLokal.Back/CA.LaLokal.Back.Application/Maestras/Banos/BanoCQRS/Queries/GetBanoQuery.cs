using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Queries
{
    public class GetBanoQuery : IRequest<ResponseBase<BanoDto>>
    {
        public int Id { get; set; }
    }

    public class GetBanoQueryHandler : IRequestHandler<GetBanoQuery, ResponseBase<BanoDto>>
    {
        private readonly IRepository<Bano> _repository;
        private readonly IMapper _mapper;

        public GetBanoQueryHandler(IRepository<Bano> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<BanoDto>> Handle(GetBanoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Bano", request.Id);
            }

            var dto = _mapper.Map<BanoDto>(entity);

            return Task.FromResult(new ResponseBase<BanoDto>(dto));
        }
    }
}