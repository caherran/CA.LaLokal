using AutoMapper;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Commands.Create
{
    public class CreatePaisCommand : IRequest<ResponseBase<int>>, IMapFrom<Pais>
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }

    public class CreatePaisCommandHandler : IRequestHandler<CreatePaisCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Pais> _repository;
        private readonly IMapper _mapper;

        public CreatePaisCommandHandler(IUnitOfWork unitOfWork, IRepository<Pais> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreatePaisCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Pais>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
