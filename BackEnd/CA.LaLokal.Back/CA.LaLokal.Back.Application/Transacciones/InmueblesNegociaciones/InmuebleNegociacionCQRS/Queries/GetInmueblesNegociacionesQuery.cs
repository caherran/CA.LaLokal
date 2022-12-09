using AutoMapper;
using AutoMapper.QueryableExtensions;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesNegociaciones.InmuebleNegociacionCQRS.Queries
{
    public class GetInmueblesNegociacionesQuery : IRequest<ResponseBase<List<InmuebleNegociacionDto>>>
    {
    }

    public class GetInmueblesNegociacionesQueryHandler : IRequestHandler<GetInmueblesNegociacionesQuery, ResponseBase<List<InmuebleNegociacionDto>>>
    {
        private readonly IRepository<InmuebleNegociacion> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesNegociacionesQueryHandler(IRepository<InmuebleNegociacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleNegociacionDto>>> Handle(GetInmueblesNegociacionesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleNegociacionDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleNegociacionDto>>(dto.ToList()));
        }
    }
}