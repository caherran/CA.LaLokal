using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosRedesSociales;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosRedesSociales.UsuarioRedSocialCQRS.Commands.Create
{
    public class CreateUsuarioRedSocialCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioRedSocial>
    {
        public Guid UsuarioId { get; set; }
public string URLFacebook { get; set; }
public string URLTwitter { get; set; }
public string URLLinkedIn { get; set; }
public string URLInstagram { get; set; }

    }

    public class CreateUsuarioRedSocialCommandHandler : IRequestHandler<CreateUsuarioRedSocialCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioRedSocial> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioRedSocialCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioRedSocial> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioRedSocialCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioRedSocial>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
