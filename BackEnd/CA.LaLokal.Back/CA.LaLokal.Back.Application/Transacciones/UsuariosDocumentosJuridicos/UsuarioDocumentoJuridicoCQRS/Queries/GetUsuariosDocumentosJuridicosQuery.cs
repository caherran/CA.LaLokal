using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosJuridicos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosJuridicos.UsuarioDocumentoJuridicoCQRS.Queries
{
    public class GetUsuariosDocumentosJuridicosQuery : IRequest<ResponseBase<List<UsuarioDocumentoJuridicoDto>>>
    {
    }

    public class GetUsuariosDocumentosJuridicosQueryHandler : IRequestHandler<GetUsuariosDocumentosJuridicosQuery, ResponseBase<List<UsuarioDocumentoJuridicoDto>>>
    {
        private readonly IRepository<UsuarioDocumentoJuridico> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosDocumentosJuridicosQueryHandler(IRepository<UsuarioDocumentoJuridico> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioDocumentoJuridicoDto>>> Handle(GetUsuariosDocumentosJuridicosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioDocumentoJuridicoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioDocumentoJuridicoDto>>(dto.ToList()));
        }
    }
}