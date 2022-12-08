using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Commands.Create
{
    public class CreateTipoNegocioCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoNegocio>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoNegocioCommandHandler : IRequestHandler<CreateTipoNegocioCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoNegocio> _repository;
        private readonly IMapper _mapper;

        public CreateTipoNegocioCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoNegocio> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoNegocioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoNegocio>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
