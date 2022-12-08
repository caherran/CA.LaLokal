using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Queries
{
    public class GetEstratosQuery : IRequest<ResponseBase<List<EstratoDto>>>
    {
    }

    public class GetEstratosQueryHandler : IRequestHandler<GetEstratosQuery, ResponseBase<List<EstratoDto>>>
    {
        private readonly IRepository<Estrato> _repository;
        private readonly IMapper _mapper;

        public GetEstratosQueryHandler(IRepository<Estrato> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EstratoDto>>> Handle(GetEstratosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EstratoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EstratoDto>>(dto.ToList()));
        }
    }
}