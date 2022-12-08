using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Queries
{
    public class GetGarajesQuery : IRequest<ResponseBase<List<GarajeDto>>>
    {
    }

    public class GetGarajesQueryHandler : IRequestHandler<GetGarajesQuery, ResponseBase<List<GarajeDto>>>
    {
        private readonly IRepository<Garaje> _repository;
        private readonly IMapper _mapper;

        public GetGarajesQueryHandler(IRepository<Garaje> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<GarajeDto>>> Handle(GetGarajesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<GarajeDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<GarajeDto>>(dto.ToList()));
        }
    }
}