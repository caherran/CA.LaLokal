using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Funcionalidades;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Funcionalidades.FuncionalidadCQRS.Commands.Create
{
    public class CreateFuncionalidadCommand : IRequest<ResponseBase<int>>, IMapFrom<Funcionalidad>
    {
        public string Descripcion { get; set; }

    }

    public class CreateFuncionalidadCommandHandler : IRequestHandler<CreateFuncionalidadCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Funcionalidad> _repository;
        private readonly IMapper _mapper;

        public CreateFuncionalidadCommandHandler(IUnitOfWork unitOfWork, IRepository<Funcionalidad> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateFuncionalidadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Funcionalidad>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
