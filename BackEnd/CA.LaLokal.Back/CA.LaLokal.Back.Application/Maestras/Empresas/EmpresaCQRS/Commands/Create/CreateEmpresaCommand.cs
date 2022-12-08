using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Empresas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Empresas.EmpresaCQRS.Commands.Create
{
    public class CreateEmpresaCommand : IRequest<ResponseBase<int>>, IMapFrom<Empresa>
    {
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public int PaisId { get; set; }
        public int DepartamentoId { get; set; }
        public int CiudadId { get; set; }
        public int ZonaBarrioId { get; set; }
        public string Direccion { get; set; }
        public string NombreContacto { get; set; }
        public string CelularContacto { get; set; }
        public string CorreoElectronico { get; set; }

    }

    public class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Empresa> _repository;
        private readonly IMapper _mapper;

        public CreateEmpresaCommandHandler(IUnitOfWork unitOfWork, IRepository<Empresa> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Empresa>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
