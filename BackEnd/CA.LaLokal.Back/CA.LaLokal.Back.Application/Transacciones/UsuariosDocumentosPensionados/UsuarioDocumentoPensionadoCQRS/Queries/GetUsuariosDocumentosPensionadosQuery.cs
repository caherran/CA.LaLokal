using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosPensionados;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Queries
{
    public class GetUsuariosDocumentosPensionadosQuery : IRequest<ResponseBase<List<UsuarioDocumentoPensionadoDto>>>
    {
    }

    public class GetUsuariosDocumentosPensionadosQueryHandler : IRequestHandler<GetUsuariosDocumentosPensionadosQuery, ResponseBase<List<UsuarioDocumentoPensionadoDto>>>
    {
        private readonly IRepository<UsuarioDocumentoPensionado> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosDocumentosPensionadosQueryHandler(IRepository<UsuarioDocumentoPensionado> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDocumentoPensionadoDto>>> Handle(GetUsuariosDocumentosPensionadosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDocumentoPensionadoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDocumentoPensionadoDto>>(dto.ToList()));
        }
    }
}