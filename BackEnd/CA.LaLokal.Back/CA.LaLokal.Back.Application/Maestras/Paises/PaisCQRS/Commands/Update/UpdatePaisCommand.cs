using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Commands.Update
{
    public class UpdatePaisCommand : IRequest<ResponseBase<bool>>, IMapFrom<Pais>
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

    }

    public class UpdatePaisCommandHandler : IRequestHandler<UpdatePaisCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Pais> _repository;
        private readonly IMapper _mapper;

        public UpdatePaisCommandHandler(IUnitOfWork unitOfWork, IRepository<Pais> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdatePaisCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Pais", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
