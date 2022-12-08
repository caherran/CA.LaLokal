using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Commands.Update
{
    public class UpdateMedioCaptacionCommand : IRequest<ResponseBase<bool>>, IMapFrom<MedioCaptacion>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateMedioCaptacionCommandHandler : IRequestHandler<UpdateMedioCaptacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<MedioCaptacion> _repository;
        private readonly IMapper _mapper;

        public UpdateMedioCaptacionCommandHandler(IUnitOfWork unitOfWork, IRepository<MedioCaptacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateMedioCaptacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("MedioCaptacion", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
