using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosExperienciasLaborales.UsuarioExperienciaLaboralCQRS.Queries
{
    public class GetUsuarioExperienciaLaboralQuery : IRequest<ResponseBase<UsuarioExperienciaLaboralDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioExperienciaLaboralQueryHandler : IRequestHandler<GetUsuarioExperienciaLaboralQuery, ResponseBase<UsuarioExperienciaLaboralDto>>
    {
        private readonly IRepository<UsuarioExperienciaLaboral> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioExperienciaLaboralQueryHandler(IRepository<UsuarioExperienciaLaboral> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioExperienciaLaboralDto>> Handle(GetUsuarioExperienciaLaboralQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioExperienciaLaboral", request.Id);
            }

            var dto = _mapper.Map<UsuarioExperienciaLaboralDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioExperienciaLaboralDto>(dto));
        }
    }
}