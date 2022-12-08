using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Portales;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Portales.PortalCQRS.Queries
{
    public class GetPortalesQuery : IRequest<ResponseBase<List<PortalDto>>>
    {
    }

    public class GetPortalesQueryHandler : IRequestHandler<GetPortalesQuery, ResponseBase<List<PortalDto>>>
    {
        private readonly IRepository<Portal> _repository;
        private readonly IMapper _mapper;

        public GetPortalesQueryHandler(IRepository<Portal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<PortalDto>>> Handle(GetPortalesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<PortalDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<PortalDto>>(dto.ToList()));
        }
    }
}