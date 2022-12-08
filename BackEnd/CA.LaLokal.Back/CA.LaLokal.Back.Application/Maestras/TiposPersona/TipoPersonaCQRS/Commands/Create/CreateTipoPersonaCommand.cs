using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposPersona;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposPersona.TipoPersonaCQRS.Commands.Create
{
    public class CreateTipoPersonaCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoPersona>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoPersonaCommandHandler : IRequestHandler<CreateTipoPersonaCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoPersona> _repository;
        private readonly IMapper _mapper;

        public CreateTipoPersonaCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoPersona> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoPersonaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoPersona>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
