using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Alcobas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Commands.Create
{
    public class CreateAlcobaCommand : IRequest<ResponseBase<int>>, IMapFrom<Alcoba>
    {
        public string Descripcion { get; set; }

    }

    public class CreateAlcobaCommandHandler : IRequestHandler<CreateAlcobaCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Alcoba> _repository;
        private readonly IMapper _mapper;

        public CreateAlcobaCommandHandler(IUnitOfWork unitOfWork, IRepository<Alcoba> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateAlcobaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Alcoba>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
