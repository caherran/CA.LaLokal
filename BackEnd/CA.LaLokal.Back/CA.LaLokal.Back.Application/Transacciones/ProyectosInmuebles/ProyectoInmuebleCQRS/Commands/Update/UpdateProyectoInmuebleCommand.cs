using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInmuebles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInmuebles.ProyectoInmuebleCQRS.Commands.Update
{
    public class UpdateProyectoInmuebleCommand : IRequest<ResponseBase<bool>>, IMapFrom<ProyectoInmueble>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }

    }

    public class UpdateProyectoInmuebleCommandHandler : IRequestHandler<UpdateProyectoInmuebleCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProyectoInmueble> _repository;
        private readonly IMapper _mapper;

        public UpdateProyectoInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<ProyectoInmueble> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateProyectoInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ProyectoInmueble", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
