using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Commands.Create
{
    public class CreateTipoClienteCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoCliente>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoClienteCommandHandler : IRequestHandler<CreateTipoClienteCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoCliente> _repository;
        private readonly IMapper _mapper;

        public CreateTipoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoCliente> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoCliente>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
