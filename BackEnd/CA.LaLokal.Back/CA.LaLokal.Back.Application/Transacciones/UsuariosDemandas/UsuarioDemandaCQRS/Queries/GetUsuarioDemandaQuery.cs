using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Queries
{
    public class GetUsuarioDemandaQuery : IRequest<ResponseBase<UsuarioDemandaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioDemandaQueryHandler : IRequestHandler<GetUsuarioDemandaQuery, ResponseBase<UsuarioDemandaDto>>
    {
        private readonly IRepository<UsuarioDemanda> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioDemandaQueryHandler(IRepository<UsuarioDemanda> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDemandaDto>> Handle(GetUsuarioDemandaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDemanda", request.Id);
            }

            var dto = _mapper.Map<UsuarioDemandaDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDemandaDto>(dto));
        }
    }
}