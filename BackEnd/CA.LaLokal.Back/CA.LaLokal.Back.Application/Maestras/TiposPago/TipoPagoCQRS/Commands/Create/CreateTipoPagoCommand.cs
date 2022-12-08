using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposPago;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPago.TipoPagoCQRS.Commands.Create
{
    public class CreateTipoPagoCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoPago>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoPagoCommandHandler : IRequestHandler<CreateTipoPagoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoPago> _repository;
        private readonly IMapper _mapper;

        public CreateTipoPagoCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoPago> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoPagoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoPago>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
