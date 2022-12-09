using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Commands.Update
{
    public class UpdateTipoIdentificacionCommand : IRequest<ResponseBase<bool>>, IMapFrom<TipoIdentificacion>
    {
        public int Id { get; set; }
public string Descripcion { get; set; }

    }

    public class UpdateTipoIdentificacionCommandHandler : IRequestHandler<UpdateTipoIdentificacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoIdentificacion> _repository;
        private readonly IMapper _mapper;

        public UpdateTipoIdentificacionCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoIdentificacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateTipoIdentificacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoIdentificacion", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
