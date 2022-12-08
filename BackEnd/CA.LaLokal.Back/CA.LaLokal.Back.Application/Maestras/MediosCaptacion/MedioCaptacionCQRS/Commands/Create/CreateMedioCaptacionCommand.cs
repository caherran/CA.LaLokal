using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Commands.Create
{
    public class CreateMedioCaptacionCommand : IRequest<ResponseBase<int>>, IMapFrom<MedioCaptacion>
    {
        public string Descripcion { get; set; }

    }

    public class CreateMedioCaptacionCommandHandler : IRequestHandler<CreateMedioCaptacionCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<MedioCaptacion> _repository;
        private readonly IMapper _mapper;

        public CreateMedioCaptacionCommandHandler(IUnitOfWork unitOfWork, IRepository<MedioCaptacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateMedioCaptacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MedioCaptacion>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
