using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosEmpleados;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosEmpleados.UsuarioDocumentoEmpleadoCQRS.Queries
{
    public class GetUsuariosDocumentosEmpleadosQuery : IRequest<ResponseBase<List<UsuarioDocumentoEmpleadoDto>>>
    {
    }

    public class GetUsuariosDocumentosEmpleadosQueryHandler : IRequestHandler<GetUsuariosDocumentosEmpleadosQuery, ResponseBase<List<UsuarioDocumentoEmpleadoDto>>>
    {
        private readonly IRepository<UsuarioDocumentoEmpleado> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosDocumentosEmpleadosQueryHandler(IRepository<UsuarioDocumentoEmpleado> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDocumentoEmpleadoDto>>> Handle(GetUsuariosDocumentosEmpleadosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDocumentoEmpleadoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDocumentoEmpleadoDto>>(dto.ToList()));
        }
    }
}