using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasExternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasExternas.InmuebleCaracteristicaExternaCQRS.Commands.Update
{
    public class UpdateInmuebleCaracteristicaExternaCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleCaracteristicaExterna>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public int CaracteristicaExternaId { get; set; }

    }

    public class UpdateInmuebleCaracteristicaExternaCommandHandler : IRequestHandler<UpdateInmuebleCaracteristicaExternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleCaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleCaracteristicaExternaCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleCaracteristicaExterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleCaracteristicaExternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleCaracteristicaExterna", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
