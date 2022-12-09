using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosRedesSociales;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosRedesSociales.UsuarioRedSocialCQRS.Commands.Update
{
    public class UpdateUsuarioRedSocialCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioRedSocial>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string URLFacebook { get; set; }
public string URLTwitter { get; set; }
public string URLLinkedIn { get; set; }
public string URLInstagram { get; set; }

    }

    public class UpdateUsuarioRedSocialCommandHandler : IRequestHandler<UpdateUsuarioRedSocialCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioRedSocial> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioRedSocialCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioRedSocial> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioRedSocialCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioRedSocial", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
