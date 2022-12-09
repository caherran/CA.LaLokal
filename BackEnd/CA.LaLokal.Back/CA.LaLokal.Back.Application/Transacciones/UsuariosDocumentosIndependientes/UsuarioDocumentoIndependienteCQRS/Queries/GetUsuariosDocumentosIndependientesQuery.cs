using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosIndependientes;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosIndependientes.UsuarioDocumentoIndependienteCQRS.Queries
{
    public class GetUsuariosDocumentosIndependientesQuery : IRequest<ResponseBase<List<UsuarioDocumentoIndependienteDto>>>
    {
    }

    public class GetUsuariosDocumentosIndependientesQueryHandler : IRequestHandler<GetUsuariosDocumentosIndependientesQuery, ResponseBase<List<UsuarioDocumentoIndependienteDto>>>
    {
        private readonly IRepository<UsuarioDocumentoIndependiente> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosDocumentosIndependientesQueryHandler(IRepository<UsuarioDocumentoIndependiente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDocumentoIndependienteDto>>> Handle(GetUsuariosDocumentosIndependientesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDocumentoIndependienteDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDocumentoIndependienteDto>>(dto.ToList()));
        }
    }
}