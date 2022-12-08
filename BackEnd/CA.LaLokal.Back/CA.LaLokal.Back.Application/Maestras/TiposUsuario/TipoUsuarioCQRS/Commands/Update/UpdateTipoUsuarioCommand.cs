using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Commands.Update
{
    public class UpdateTipoUsuarioCommand : IRequest<ResponseBase<bool>>, IMapFrom<TipoUsuario>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateTipoUsuarioCommandHandler : IRequestHandler<UpdateTipoUsuarioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoUsuario> _repository;
        private readonly IMapper _mapper;

        public UpdateTipoUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoUsuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateTipoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoUsuario", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
