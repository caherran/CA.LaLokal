using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Commands.Create
{
    public class CreateGarajeCommand : IRequest<ResponseBase<int>>, IMapFrom<Garaje>
    {
        public string Descripcion { get; set; }

    }

    public class CreateGarajeCommandHandler : IRequestHandler<CreateGarajeCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Garaje> _repository;
        private readonly IMapper _mapper;

        public CreateGarajeCommandHandler(IUnitOfWork unitOfWork, IRepository<Garaje> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateGarajeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Garaje>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
