using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.Inmuebles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.Inmuebles.InmuebleCQRS.Commands.Update
{
    public class UpdateInmuebleCommand : IRequest<ResponseBase<bool>>, IMapFrom<Inmueble>
    {
        public Guid Id { get; set; }
public string Nombre { get; set; }
public string Codigo { get; set; }
public int EstadoPublicacionId { get; set; }
public Guid GestorInmuebleId { get; set; }
public int TipoInmuebleId { get; set; }
public string MatriculaInmobiliaria { get; set; }
public int EstadoFisicoPropiedadId { get; set; }
public string Ano { get; set; }
public int EstratoId { get; set; }
public int AlcobaId { get; set; }
public int BanoId { get; set; }
public int GarajeId { get; set; }
public int PisoId { get; set; }
public Decimal AreaPrivada { get; set; }
public Decimal AreaConstruIda { get; set; }
public Decimal AreaTotal { get; set; }
public Decimal ValorGasNatural { get; set; }
public Decimal ValorTelefoniaInternet { get; set; }
public Decimal ValorEnergia { get; set; }
public Decimal ValorAgua { get; set; }
public int CiudadId { get; set; }
public int ZonaBarrioId { get; set; }
public string CodigoPostal { get; set; }
public string Direccion { get; set; }
public bool NoPublicar { get; set; }
public bool SoloZona { get; set; }
public bool PuntoExacto { get; set; }
public string DireccionMapa { get; set; }
public string Observaciones { get; set; }

    }

    public class UpdateInmuebleCommandHandler : IRequestHandler<UpdateInmuebleCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Inmueble> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<Inmueble> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Inmueble", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
