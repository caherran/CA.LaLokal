using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosJuridicos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosJuridicos.UsuarioDocumentoJuridicoCQRS.Queries
{
    public class GetUsuarioDocumentoJuridicoQuery : IRequest<ResponseBase<UsuarioDocumentoJuridicoDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioDocumentoJuridicoQueryHandler : IRequestHandler<GetUsuarioDocumentoJuridicoQuery, ResponseBase<UsuarioDocumentoJuridicoDto>>
    {
        private readonly IRepository<UsuarioDocumentoJuridico> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioDocumentoJuridicoQueryHandler(IRepository<UsuarioDocumentoJuridico> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioDocumentoJuridicoDto>> Handle(GetUsuarioDocumentoJuridicoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoJuridico", request.Id);
            }

            var dto = _mapper.Map<UsuarioDocumentoJuridicoDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioDocumentoJuridicoDto>(dto));
        }
    }
}