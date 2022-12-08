using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Commands.Update
{
    public class UpdateCaracteristicaExternaCommand : IRequest<ResponseBase<bool>>, IMapFrom<CaracteristicaExterna>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateCaracteristicaExternaCommandHandler : IRequestHandler<UpdateCaracteristicaExternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public UpdateCaracteristicaExternaCommandHandler(IUnitOfWork unitOfWork, IRepository<CaracteristicaExterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateCaracteristicaExternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("CaracteristicaExterna", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
