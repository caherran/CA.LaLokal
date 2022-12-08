using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Alcobas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Commands.Update
{
    public class UpdateAlcobaCommand : IRequest<ResponseBase<bool>>, IMapFrom<Alcoba>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateAlcobaCommandHandler : IRequestHandler<UpdateAlcobaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Alcoba> _repository;
        private readonly IMapper _mapper;

        public UpdateAlcobaCommandHandler(IUnitOfWork unitOfWork, IRepository<Alcoba> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateAlcobaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Alcoba", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
