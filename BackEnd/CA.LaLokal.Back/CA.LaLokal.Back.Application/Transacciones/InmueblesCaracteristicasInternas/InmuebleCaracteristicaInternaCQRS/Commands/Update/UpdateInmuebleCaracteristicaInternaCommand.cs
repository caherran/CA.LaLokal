using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Commands.Update
{
    public class UpdateInmuebleCaracteristicaInternaCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleCaracteristicaInterna>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public int CaracteristicaInternaId { get; set; }

    }

    public class UpdateInmuebleCaracteristicaInternaCommandHandler : IRequestHandler<UpdateInmuebleCaracteristicaInternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleCaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleCaracteristicaInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleCaracteristicaInterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleCaracteristicaInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleCaracteristicaInterna", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
