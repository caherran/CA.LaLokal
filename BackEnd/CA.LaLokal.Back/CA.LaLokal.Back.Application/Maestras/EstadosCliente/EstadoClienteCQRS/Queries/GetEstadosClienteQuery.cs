using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosCliente;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCliente.EstadoClienteCQRS.Queries
{
    public class GetEstadosClienteQuery : IRequest<ResponseBase<List<EstadoClienteDto>>>
    {
    }

    public class GetEstadosClienteQueryHandler : IRequestHandler<GetEstadosClienteQuery, ResponseBase<List<EstadoClienteDto>>>
    {
        private readonly IRepository<EstadoCliente> _repository;
        private readonly IMapper _mapper;

        public GetEstadosClienteQueryHandler(IRepository<EstadoCliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EstadoClienteDto>>> Handle(GetEstadosClienteQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EstadoClienteDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EstadoClienteDto>>(dto.ToList()));
        }
    }
}