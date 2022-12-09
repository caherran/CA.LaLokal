using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosDocumentos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosDocumentos.ProyectoDocumentoCQRS.Queries
{
    public class GetProyectosDocumentosQuery : IRequest<ResponseBase<List<ProyectoDocumentoDto>>>
    {
    }

    public class GetProyectosDocumentosQueryHandler : IRequestHandler<GetProyectosDocumentosQuery, ResponseBase<List<ProyectoDocumentoDto>>>
    {
        private readonly IRepository<ProyectoDocumento> _repository;
        private readonly IMapper _mapper;

        public GetProyectosDocumentosQueryHandler(IRepository<ProyectoDocumento> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<ProyectoDocumentoDto>>> Handle(GetProyectosDocumentosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<ProyectoDocumentoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<ProyectoDocumentoDto>>(dto.ToList()));
        }
    }
}