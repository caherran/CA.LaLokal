using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosCliente;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCliente.EstadoClienteCQRS.Queries
{
    public class GetEstadoClienteQuery : IRequest<ResponseBase<EstadoClienteDto>>
    {
        public int Id { get; set; }
    }

    public class GetEstadoClienteQueryHandler : IRequestHandler<GetEstadoClienteQuery, ResponseBase<EstadoClienteDto>>
    {
        private readonly IRepository<EstadoCliente> _repository;
        private readonly IMapper _mapper;

        public GetEstadoClienteQueryHandler(IRepository<EstadoCliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EstadoClienteDto>> Handle(GetEstadoClienteQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoCliente", request.Id);
            }

            var dto = _mapper.Map<EstadoClienteDto>(entity);

            return Task.FromResult(new ResponseBase<EstadoClienteDto>(dto));
        }
    }
}