using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Funcionalidades;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Funcionalidades.FuncionalidadCQRS.Commands.Update
{
    public class UpdateFuncionalidadCommand : IRequest<ResponseBase<bool>>, IMapFrom<Funcionalidad>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateFuncionalidadCommandHandler : IRequestHandler<UpdateFuncionalidadCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Funcionalidad> _repository;
        private readonly IMapper _mapper;

        public UpdateFuncionalidadCommandHandler(IUnitOfWork unitOfWork, IRepository<Funcionalidad> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateFuncionalidadCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Funcionalidad", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
