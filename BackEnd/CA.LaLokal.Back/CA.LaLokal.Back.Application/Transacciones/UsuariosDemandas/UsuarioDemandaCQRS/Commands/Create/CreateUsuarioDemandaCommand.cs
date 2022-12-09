using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDemandas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDemandas.UsuarioDemandaCQRS.Commands.Create
{
    public class CreateUsuarioDemandaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioDemanda>
    {
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

    public class CreateUsuarioDemandaCommandHandler : IRequestHandler<CreateUsuarioDemandaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDemanda> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioDemandaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDemanda> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioDemandaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioDemanda>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
