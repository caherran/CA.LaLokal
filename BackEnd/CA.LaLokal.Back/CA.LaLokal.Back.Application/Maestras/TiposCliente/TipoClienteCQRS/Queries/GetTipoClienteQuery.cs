using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Queries
{
    public class GetTipoClienteQuery : IRequest<ResponseBase<TipoClienteDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoClienteQueryHandler : IRequestHandler<GetTipoClienteQuery, ResponseBase<TipoClienteDto>>
    {
        private readonly IRepository<TipoCliente> _repository;
        private readonly IMapper _mapper;

        public GetTipoClienteQueryHandler(IRepository<TipoCliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoClienteDto>> Handle(GetTipoClienteQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoCliente", request.Id);
            }

            var dto = _mapper.Map<TipoClienteDto>(entity);

            return Task.FromResult(new ResponseBase<TipoClienteDto>(dto));
        }
    }
}