using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Tiempos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Tiempos.TiempoCQRS.Commands.Update
{
    public class UpdateTiempoCommand : IRequest<ResponseBase<bool>>, IMapFrom<Tiempo>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateTiempoCommandHandler : IRequestHandler<UpdateTiempoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Tiempo> _repository;
        private readonly IMapper _mapper;

        public UpdateTiempoCommandHandler(IUnitOfWork unitOfWork, IRepository<Tiempo> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateTiempoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Tiempo", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
