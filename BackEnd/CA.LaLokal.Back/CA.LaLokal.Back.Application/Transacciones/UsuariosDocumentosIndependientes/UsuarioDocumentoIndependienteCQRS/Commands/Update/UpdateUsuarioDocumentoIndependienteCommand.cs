using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosIndependientes;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosIndependientes.UsuarioDocumentoIndependienteCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoIndependienteCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioDocumentoIndependiente>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string ExtractoBancario3meses { get; set; }
public string DeclaracionRenta2UltimosAnos { get; set; }
public string CertificadoCamaraComercio { get; set; }
public string CopiaDocumentoIdentidad { get; set; }

    }

    public class UpdateUsuarioDocumentoIndependienteCommandHandler : IRequestHandler<UpdateUsuarioDocumentoIndependienteCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoIndependiente> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioDocumentoIndependienteCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoIndependiente> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioDocumentoIndependienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoIndependiente", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
