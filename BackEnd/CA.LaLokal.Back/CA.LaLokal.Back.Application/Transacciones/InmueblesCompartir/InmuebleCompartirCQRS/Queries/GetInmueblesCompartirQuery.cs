using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCompartir;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCompartir.InmuebleCompartirCQRS.Queries
{
    public class GetInmueblesCompartirQuery : IRequest<ResponseBase<List<InmuebleCompartirDto>>>
    {
    }

    public class GetInmueblesCompartirQueryHandler : IRequestHandler<GetInmueblesCompartirQuery, ResponseBase<List<InmuebleCompartirDto>>>
    {
        private readonly IRepository<InmuebleCompartir> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesCompartirQueryHandler(IRepository<InmuebleCompartir> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleCompartirDto>>> Handle(GetInmueblesCompartirQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleCompartirDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleCompartirDto>>(dto.ToList()));
        }
    }
}