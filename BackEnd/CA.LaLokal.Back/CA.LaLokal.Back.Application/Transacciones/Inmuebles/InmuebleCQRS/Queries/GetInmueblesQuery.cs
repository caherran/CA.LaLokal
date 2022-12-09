using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Queries
{
    public class GetInmueblesQuery : IRequest<ResponseBase<List<InmuebleDto>>>
    {
    }

    public class GetInmueblesQueryHandler : IRequestHandler<GetInmueblesQuery, ResponseBase<List<InmuebleDto>>>
    {
        private readonly IRepository<Inmueble> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesQueryHandler(IRepository<Inmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleDto>>> Handle(GetInmueblesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleDto>>(dto.ToList()));
        }
    }
}