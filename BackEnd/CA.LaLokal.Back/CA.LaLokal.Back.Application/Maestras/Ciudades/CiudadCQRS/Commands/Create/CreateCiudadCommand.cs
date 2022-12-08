using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Commands.Create
{
    public class CreateCiudadCommand : IRequest<ResponseBase<int>>, IMapFrom<Ciudad>
    {
        public int DepartamentoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

    public class CreateCiudadCommandHandler : IRequestHandler<CreateCiudadCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ciudad> _repository;
        private readonly IMapper _mapper;

        public CreateCiudadCommandHandler(IUnitOfWork unitOfWork, IRepository<Ciudad> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateCiudadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Ciudad>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
