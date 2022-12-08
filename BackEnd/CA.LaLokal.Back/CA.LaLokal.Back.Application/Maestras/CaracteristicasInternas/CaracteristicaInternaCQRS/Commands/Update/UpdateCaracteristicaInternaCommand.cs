using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Commands.Update
{
    public class UpdateCaracteristicaInternaCommand : IRequest<ResponseBase<bool>>, IMapFrom<CaracteristicaInterna>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateCaracteristicaInternaCommandHandler : IRequestHandler<UpdateCaracteristicaInternaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public UpdateCaracteristicaInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<CaracteristicaInterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateCaracteristicaInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("CaracteristicaInterna", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
