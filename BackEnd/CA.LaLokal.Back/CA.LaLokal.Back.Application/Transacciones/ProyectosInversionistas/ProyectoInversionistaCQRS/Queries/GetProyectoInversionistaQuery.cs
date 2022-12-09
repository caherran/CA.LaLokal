using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInversionistas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInversionistas.ProyectoInversionistaCQRS.Queries
{
    public class GetProyectoInversionistaQuery : IRequest<ResponseBase<ProyectoInversionistaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetProyectoInversionistaQueryHandler : IRequestHandler<GetProyectoInversionistaQuery, ResponseBase<ProyectoInversionistaDto>>
    {
        private readonly IRepository<ProyectoInversionista> _repository;
        private readonly IMapper _mapper;

        public GetProyectoInversionistaQueryHandler(IRepository<ProyectoInversionista> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<ProyectoInversionistaDto>> Handle(GetProyectoInversionistaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ProyectoInversionista", request.Id);
            }

            var dto = _mapper.Map<ProyectoInversionistaDto>(entity);

            return Task.FromResult(new ResponseBase<ProyectoInversionistaDto>(dto));
        }
    }
}