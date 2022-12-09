using AutoMapper;
using CA.GuidGenerator;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesNegociaciones.InmuebleNegociacionCQRS.Commands.Create
{
    public class CreateInmuebleNegociacionCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleNegociacion>
    {
        public Guid InmuebleId { get; set; }
        public int TipoNegocioId { get; set; }
        public int TipoMonedaId { get; set; }
        public Decimal PrecioVenta { get; set; }
        public Decimal PrecioAlquiler { get; set; }
        public int TiempoId { get; set; }
        public Decimal ValorAdministracion { get; set; }
        public bool TienePorcentajePrecio { get; set; }
        public Decimal ValorPorcentajePrecio { get; set; }
        public bool TieneCantIdadFija { get; set; }
        public Decimal ValorCantIdadFija { get; set; }
        public bool TieneContratoExclusivIdad { get; set; }
        public DateTime FechaExpiracionContrato { get; set; }

    }

    public class CreateInmuebleNegociacionCommandHandler : IRequestHandler<CreateInmuebleNegociacionCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleNegociacion> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleNegociacionCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleNegociacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleNegociacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleNegociacion>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
