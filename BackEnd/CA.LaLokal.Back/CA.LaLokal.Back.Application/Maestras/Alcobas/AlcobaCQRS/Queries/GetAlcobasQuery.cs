using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Alcobas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Queries
{
    public class GetAlcobasQuery : IRequest<ResponseBase<List<AlcobaDto>>>
    {
    }

    public class GetAlcobasQueryHandler : IRequestHandler<GetAlcobasQuery, ResponseBase<List<AlcobaDto>>>
    {
        private readonly IRepository<Alcoba> _repository;
        private readonly IMapper _mapper;

        public GetAlcobasQueryHandler(IRepository<Alcoba> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<AlcobaDto>>> Handle(GetAlcobasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<AlcobaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<AlcobaDto>>(dto.ToList()));
        }
    }
}