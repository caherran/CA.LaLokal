using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Pisos.PisoCQRS.Commands.Create
{
    public class CreatePisoCommand : IRequest<ResponseBase<int>>, IMapFrom<Piso>
    {
        public string Descripcion { get; set; }

    }

    public class CreatePisoCommandHandler : IRequestHandler<CreatePisoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Piso> _repository;
        private readonly IMapper _mapper;

        public CreatePisoCommandHandler(IUnitOfWork unitOfWork, IRepository<Piso> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreatePisoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Piso>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
