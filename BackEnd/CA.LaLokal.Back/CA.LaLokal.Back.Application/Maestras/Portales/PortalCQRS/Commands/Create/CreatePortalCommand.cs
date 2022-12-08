using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Portales;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Portales.PortalCQRS.Commands.Create
{
    public class CreatePortalCommand : IRequest<ResponseBase<int>>, IMapFrom<Portal>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string URLPortal { get; set; }
        public string Estatus { get; set; }

    }

    public class CreatePortalCommandHandler : IRequestHandler<CreatePortalCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Portal> _repository;
        private readonly IMapper _mapper;

        public CreatePortalCommandHandler(IUnitOfWork unitOfWork, IRepository<Portal> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreatePortalCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Portal>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
