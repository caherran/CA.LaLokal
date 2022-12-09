using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosMultimedia;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosMultimedia.UsuarioMultimediaCQRS.Commands.Update
{
    public class UpdateUsuarioMultimediaCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioMultimedia>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string URLImagen { get; set; }

    }

    public class UpdateUsuarioMultimediaCommandHandler : IRequestHandler<UpdateUsuarioMultimediaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioMultimedia> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioMultimediaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioMultimedia> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioMultimediaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioMultimedia", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
