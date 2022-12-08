using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Commands.Create
{
    public class CreateBanoCommand : IRequest<ResponseBase<int>>, IMapFrom<Bano>
    {
        public string Descripcion { get; set; }

    }

    public class CreateBanoCommandHandler : IRequestHandler<CreateBanoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bano> _repository;
        private readonly IMapper _mapper;

        public CreateBanoCommandHandler(IUnitOfWork unitOfWork, IRepository<Bano> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateBanoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Bano>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
