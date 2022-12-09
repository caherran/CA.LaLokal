using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosJuridicos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosJuridicos.UsuarioDocumentoJuridicoCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoJuridicoCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioDocumentoJuridico>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string ExtractoBancario { get; set; }
public string DeclaracionRenta { get; set; }
public string CertificadoCamaraComercio { get; set; }
public string EstadosFinancieros { get; set; }
public string CopiaCedulaRepresentanteLegal { get; set; }

    }

    public class UpdateUsuarioDocumentoJuridicoCommandHandler : IRequestHandler<UpdateUsuarioDocumentoJuridicoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoJuridico> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioDocumentoJuridicoCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoJuridico> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioDocumentoJuridicoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoJuridico", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
