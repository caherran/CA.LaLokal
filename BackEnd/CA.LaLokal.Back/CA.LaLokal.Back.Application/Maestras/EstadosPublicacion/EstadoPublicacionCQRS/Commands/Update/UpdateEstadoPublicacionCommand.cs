using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Commands.Update
{
    public class UpdateEstadoPublicacionCommand : IRequest<ResponseBase<bool>>, IMapFrom<EstadoPublicacion>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateEstadoPublicacionCommandHandler : IRequestHandler<UpdateEstadoPublicacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoPublicacion> _repository;
        private readonly IMapper _mapper;

        public UpdateEstadoPublicacionCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoPublicacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateEstadoPublicacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoPublicacion", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
