using AutoMapper;
using CA.Domain.Auditable.Exceptions;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesNegociaciones;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesNegociaciones.InmuebleNegociacionCQRS.Commands.Update
{
    public class UpdateInmuebleNegociacionCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleNegociacion>
    {
        public Guid Id { get; set; }
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

    public class UpdateInmuebleNegociacionCommandHandler : IRequestHandler<UpdateInmuebleNegociacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleNegociacion> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleNegociacionCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleNegociacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleNegociacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleNegociacion", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
