using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosProyecto.EstadoProyectoCQRS.Commands.Update
{
    public class UpdateEstadoProyectoCommand : IRequest<ResponseBase<bool>>, IMapFrom<EstadoProyecto>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateEstadoProyectoCommandHandler : IRequestHandler<UpdateEstadoProyectoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoProyecto> _repository;
        private readonly IMapper _mapper;

        public UpdateEstadoProyectoCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoProyecto> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateEstadoProyectoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoProyecto", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
