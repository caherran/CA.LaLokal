using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries
{
    public class GetCiudadesQuery : IRequest<ResponseBase<List<CiudadDto>>>
    {
    }

    public class GetCiudadesQueryHandler : IRequestHandler<GetCiudadesQuery, ResponseBase<List<CiudadDto>>>
    {
        private readonly IRepository<Ciudad> _repository;
        private readonly IMapper _mapper;

        public GetCiudadesQueryHandler(IRepository<Ciudad> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<CiudadDto>>> Handle(GetCiudadesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<CiudadDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<CiudadDto>>(dto.ToList()));
        }
    }
}