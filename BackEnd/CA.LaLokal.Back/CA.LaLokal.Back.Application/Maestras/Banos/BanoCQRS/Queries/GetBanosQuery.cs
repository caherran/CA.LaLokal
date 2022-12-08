using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Queries
{
    public class GetBanosQuery : IRequest<ResponseBase<List<BanoDto>>>
    {
    }

    public class GetBanosQueryHandler : IRequestHandler<GetBanosQuery, ResponseBase<List<BanoDto>>>
    {
        private readonly IRepository<Bano> _repository;
        private readonly IMapper _mapper;

        public GetBanosQueryHandler(IRepository<Bano> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<BanoDto>>> Handle(GetBanosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<BanoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<BanoDto>>(dto.ToList()));
        }
    }
}