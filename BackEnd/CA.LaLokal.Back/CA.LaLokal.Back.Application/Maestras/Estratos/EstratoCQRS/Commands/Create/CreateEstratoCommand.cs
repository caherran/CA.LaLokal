using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Commands.Create
{
    public class CreateEstratoCommand : IRequest<ResponseBase<int>>, IMapFrom<Estrato>
    {
        public string Descripcion { get; set; }

    }

    public class CreateEstratoCommandHandler : IRequestHandler<CreateEstratoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Estrato> _repository;
        private readonly IMapper _mapper;

        public CreateEstratoCommandHandler(IUnitOfWork unitOfWork, IRepository<Estrato> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEstratoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Estrato>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
