using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosDocumentos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosDocumentos.ProyectoDocumentoCQRS.Commands.Update
{
    public class UpdateProyectoDocumentoCommand : IRequest<ResponseBase<bool>>, IMapFrom<ProyectoDocumento>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public string Descripcion { get; set; }
public string URLDocumento { get; set; }

    }

    public class UpdateProyectoDocumentoCommandHandler : IRequestHandler<UpdateProyectoDocumentoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProyectoDocumento> _repository;
        private readonly IMapper _mapper;

        public UpdateProyectoDocumentoCommandHandler(IUnitOfWork unitOfWork, IRepository<ProyectoDocumento> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateProyectoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ProyectoDocumento", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
