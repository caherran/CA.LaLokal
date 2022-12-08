using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Queries
{
    public class GetTiposClienteQuery : IRequest<ResponseBase<List<TipoClienteDto>>>
    {
    }

    public class GetTiposClienteQueryHandler : IRequestHandler<GetTiposClienteQuery, ResponseBase<List<TipoClienteDto>>>
    {
        private readonly IRepository<TipoCliente> _repository;
        private readonly IMapper _mapper;

        public GetTiposClienteQueryHandler(IRepository<TipoCliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<TipoClienteDto>>> Handle(GetTiposClienteQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<TipoClienteDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<TipoClienteDto>>(dto.ToList()));
        }
    }
}