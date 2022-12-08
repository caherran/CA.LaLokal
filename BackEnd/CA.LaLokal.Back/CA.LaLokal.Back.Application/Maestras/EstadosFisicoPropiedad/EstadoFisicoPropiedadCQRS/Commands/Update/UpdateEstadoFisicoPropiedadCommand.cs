using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Commands.Update
{
    public class UpdateEstadoFisicoPropiedadCommand : IRequest<ResponseBase<bool>>, IMapFrom<EstadoFisicoPropiedad>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateEstadoFisicoPropiedadCommandHandler : IRequestHandler<UpdateEstadoFisicoPropiedadCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoFisicoPropiedad> _repository;
        private readonly IMapper _mapper;

        public UpdateEstadoFisicoPropiedadCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoFisicoPropiedad> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateEstadoFisicoPropiedadCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoFisicoPropiedad", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
