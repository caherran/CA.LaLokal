using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Proyectos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Proyectos.ProyectoCQRS.Commands.Update
{
    public class UpdateProyectoCommand : IRequest<ResponseBase<bool>>, IMapFrom<Proyecto>
    {
        public Guid Id { get; set; }
public Guid UsuarioEncargadoId { get; set; }
public string Codigo { get; set; }
public string Descripcion { get; set; }
public int EstadoProyectoId { get; set; }
public int TipoInmuebleId { get; set; }
public int TipoNegocioId { get; set; }
public int TipoMonedaId { get; set; }
public Decimal MontoTotal { get; set; }
public int CantIdadInversionistas { get; set; }
public Decimal MontoMinimoInversion { get; set; }
public Decimal MontoMaximoInversion { get; set; }
public Decimal RentabilIdadTotal { get; set; }
public Decimal RentabilIdadAnalizada { get; set; }
public string PlazoRetornoEsperado { get; set; }
public Decimal TotalAFinanciar { get; set; }
public Decimal CostoProyecto { get; set; }
public Decimal IngresoEstimadoVenta { get; set; }
public Decimal RentabilIdad { get; set; }
public Decimal CreacionSpA { get; set; }
public Decimal InscripciónSpA { get; set; }
public Decimal EstudioTítulos { get; set; }
public Decimal PromesaEscrituraCompra { get; set; }
public Decimal InscripciónPropiedadCBR { get; set; }
public Decimal ContabilIdadRentaAnual { get; set; }
public Decimal ContabilIdadMensual { get; set; }
public Decimal Contribuciones { get; set; }
public Decimal PatenteComercialSpA { get; set; }
public Decimal CompraTerreno { get; set; }
public Decimal ComisiónCorretajeCompra { get; set; }
public Decimal ProyectoParcelación { get; set; }
public Decimal MarketingVenta { get; set; }
public Decimal FondoReservaProyecto { get; set; }
public Decimal PromesaEscrituraVenta { get; set; }
public Decimal CierreSpA { get; set; }

    }

    public class UpdateProyectoCommandHandler : IRequestHandler<UpdateProyectoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Proyecto> _repository;
        private readonly IMapper _mapper;

        public UpdateProyectoCommandHandler(IUnitOfWork unitOfWork, IRepository<Proyecto> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateProyectoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Proyecto", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
