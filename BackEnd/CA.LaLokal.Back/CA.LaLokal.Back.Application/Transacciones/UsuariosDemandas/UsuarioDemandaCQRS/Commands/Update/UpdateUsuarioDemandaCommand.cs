using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Commands.Update
{
    public class UpdateUsuarioDemandaCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioDemanda>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public int TipoInmuebleId { get; set; }
public int TipoNegocioId { get; set; }
public int CiudadId { get; set; }
public int ZonaBarrioId { get; set; }
public int TipoMonedaId { get; set; }
public Decimal PresupuestoMinimo { get; set; }
public Decimal PresupuestoMaximo { get; set; }
public Decimal AreaMinima { get; set; }
public Decimal AreaMaxima { get; set; }
public int BanoId { get; set; }
public int GarajeId { get; set; }
public string DetallePropiedad { get; set; }

    }

    public class UpdateUsuarioDemandaCommandHandler : IRequestHandler<UpdateUsuarioDemandaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDemanda> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioDemandaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDemanda> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioDemandaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDemanda", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
