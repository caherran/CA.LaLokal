using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosExperienciasLaborales.UsuarioExperienciaLaboralCQRS.Queries
{
    public class GetUsuariosExperienciasLaboralesQuery : IRequest<ResponseBase<List<UsuarioExperienciaLaboralDto>>>
    {
    }

    public class GetUsuariosExperienciasLaboralesQueryHandler : IRequestHandler<GetUsuariosExperienciasLaboralesQuery, ResponseBase<List<UsuarioExperienciaLaboralDto>>>
    {
        private readonly IRepository<UsuarioExperienciaLaboral> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosExperienciasLaboralesQueryHandler(IRepository<UsuarioExperienciaLaboral> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioExperienciaLaboralDto>>> Handle(GetUsuariosExperienciasLaboralesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioExperienciaLaboralDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioExperienciaLaboralDto>>(dto.ToList()));
        }
    }
}