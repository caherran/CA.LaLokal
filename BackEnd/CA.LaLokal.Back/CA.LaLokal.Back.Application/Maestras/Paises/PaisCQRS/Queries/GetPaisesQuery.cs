using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Queries
{
    public class GetPaisesQuery : IRequest<ResponseBase<List<PaisDto>>>
    {
    }

    public class GetPaisesQueryHandler : IRequestHandler<GetPaisesQuery, ResponseBase<List<PaisDto>>>
    {
        private readonly IRepository<Pais> _repository;
        private readonly IMapper _mapper;

        public GetPaisesQueryHandler(IRepository<Pais> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<PaisDto>>> Handle(GetPaisesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<PaisDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<PaisDto>>(dto.ToList()));
        }
    }
}