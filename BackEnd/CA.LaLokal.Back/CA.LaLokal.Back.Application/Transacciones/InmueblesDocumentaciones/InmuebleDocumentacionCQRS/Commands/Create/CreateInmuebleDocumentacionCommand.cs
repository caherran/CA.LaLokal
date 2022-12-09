using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesDocumentaciones;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesDocumentaciones.InmuebleDocumentacionCQRS.Commands.Create
{
    public class CreateInmuebleDocumentacionCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleDocumentacion>
    {
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

    public class CreateInmuebleDocumentacionCommandHandler : IRequestHandler<CreateInmuebleDocumentacionCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleDocumentacion> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleDocumentacionCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleDocumentacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleDocumentacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleDocumentacion>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
