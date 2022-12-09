using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosEmpleados;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosEmpleados.UsuarioDocumentoEmpleadoCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoEmpleadoCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioDocumentoEmpleado>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string ExtractoBancario3meses { get; set; }
public string CertificadoLaboral { get; set; }
public string DeclaracionRenta2UltimosAnos { get; set; }
public string CopiaDocumentoIdentidad { get; set; }

    }

    public class UpdateUsuarioDocumentoEmpleadoCommandHandler : IRequestHandler<UpdateUsuarioDocumentoEmpleadoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoEmpleado> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioDocumentoEmpleadoCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoEmpleado> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioDocumentoEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoEmpleado", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
