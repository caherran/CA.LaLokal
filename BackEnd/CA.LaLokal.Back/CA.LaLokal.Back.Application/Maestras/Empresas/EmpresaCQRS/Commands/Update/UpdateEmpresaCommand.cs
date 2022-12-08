using AutoMapper;
using CA.Domain.Auditable.Exceptions;
using CA.LaLokal.Back.Domain.Maestras.Empresas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.Empresas.EmpresaCQRS.Commands.Update
{
    public class UpdateEmpresaCommand : IRequest<ResponseBase<bool>>, IMapFrom<Empresa>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public int CiudadId { get; set; }
        public int ZonaBarrioId { get; set; }
        public string Direccion { get; set; }
        public string NombreContacto { get; set; }
        public string CelularContacto { get; set; }
        public string CorreoElectronico { get; set; }

    }

    public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Empresa> _repository;
        private readonly IMapper _mapper;

        public UpdateEmpresaCommandHandler(IUnitOfWork unitOfWork, IRepository<Empresa> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Empresa", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
