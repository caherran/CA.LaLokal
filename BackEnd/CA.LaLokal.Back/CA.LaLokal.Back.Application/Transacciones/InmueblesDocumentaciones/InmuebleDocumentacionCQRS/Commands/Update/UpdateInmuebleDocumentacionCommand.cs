using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesDocumentaciones;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesDocumentaciones.InmuebleDocumentacionCQRS.Commands.Update
{
    public class UpdateInmuebleDocumentacionCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleDocumentacion>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public string CopiaCedula { get; set; }
public string CertificadoCamaraComercio { get; set; }
public string CopiaEscrituraCompraventa { get; set; }
public string CopiaPromesaCompraventa { get; set; }
public string RUT { get; set; }
public string CertificadoLibertad { get; set; }
public string UltimoPagoImpuestoPredial { get; set; }
public string CopiaRecibosServiciosPublicosPagos { get; set; }
public string PazSalvoAdministración { get; set; }
public string FirmaContratoAdministración { get; set; }
public string EntregaCartaInstrucciones { get; set; }
public string ContratoCompraAlquiler { get; set; }

    }

    public class UpdateInmuebleDocumentacionCommandHandler : IRequestHandler<UpdateInmuebleDocumentacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleDocumentacion> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleDocumentacionCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleDocumentacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleDocumentacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleDocumentacion", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
