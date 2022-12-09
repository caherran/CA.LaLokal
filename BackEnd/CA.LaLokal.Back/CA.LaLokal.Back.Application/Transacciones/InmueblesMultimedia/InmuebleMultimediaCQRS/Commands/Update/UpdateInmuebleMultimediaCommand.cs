using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimedia;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimedia.InmuebleMultimediaCQRS.Commands.Update
{
    public class UpdateInmuebleMultimediaCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleMultimedia>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public string URLVideo { get; set; }
public string URLTour360 { get; set; }

    }

    public class UpdateInmuebleMultimediaCommandHandler : IRequestHandler<UpdateInmuebleMultimediaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleMultimedia> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleMultimediaCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleMultimedia> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleMultimediaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleMultimedia", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
