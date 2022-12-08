using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Commands.Update
{
    public class UpdateDepartamentoCommand : IRequest<ResponseBase<bool>>, IMapFrom<Departamento>
    {
        public int Id { get; set; }
        public int PaisId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

    public class UpdateDepartamentoCommandHandler : IRequestHandler<UpdateDepartamentoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Departamento> _repository;
        private readonly IMapper _mapper;

        public UpdateDepartamentoCommandHandler(IUnitOfWork unitOfWork, IRepository<Departamento> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Departamento", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
