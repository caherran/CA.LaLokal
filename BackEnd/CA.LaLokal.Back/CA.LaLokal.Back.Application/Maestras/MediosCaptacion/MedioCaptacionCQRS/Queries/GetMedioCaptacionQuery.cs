using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Queries
{
    public class GetMedioCaptacionQuery : IRequest<ResponseBase<MedioCaptacionDto>>
    {
        public int Id { get; set; }
    }

    public class GetMedioCaptacionQueryHandler : IRequestHandler<GetMedioCaptacionQuery, ResponseBase<MedioCaptacionDto>>
    {
        private readonly IRepository<MedioCaptacion> _repository;
        private readonly IMapper _mapper;

        public GetMedioCaptacionQueryHandler(IRepository<MedioCaptacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<MedioCaptacionDto>> Handle(GetMedioCaptacionQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("MedioCaptacion", request.Id);
            }

            var dto = _mapper.Map<MedioCaptacionDto>(entity);

            return Task.FromResult(new ResponseBase<MedioCaptacionDto>(dto));
        }
    }
}