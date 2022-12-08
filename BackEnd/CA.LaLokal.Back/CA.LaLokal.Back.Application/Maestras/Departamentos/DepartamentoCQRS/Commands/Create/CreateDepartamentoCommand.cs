using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Commands.Create
{
    public class CreateDepartamentoCommand : IRequest<ResponseBase<int>>, IMapFrom<Departamento>
    {
        public int PaisId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

    public class CreateDepartamentoCommandHandler : IRequestHandler<CreateDepartamentoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Departamento> _repository;
        private readonly IMapper _mapper;

        public CreateDepartamentoCommandHandler(IUnitOfWork unitOfWork, IRepository<Departamento> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Departamento>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
