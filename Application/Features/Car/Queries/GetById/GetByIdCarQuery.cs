using AutoMapper;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Queries.GetById
{
    public class GetByIdCarQuery : IRequest<GetByIdCarQueryResponse>
    {
        public Guid Id { get; set; }
        public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarQueryResponse>
        {
            private readonly IMapper mapper;
            private readonly ICarRepository carRepository;

            public GetByIdCarQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                this.mapper = mapper;
                this.carRepository = carRepository;
            }

            public async Task<GetByIdCarQueryResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Car car = await carRepository.GetByIdAsync(request.Id);
                GetByIdCarQueryResponse response = mapper.Map<GetByIdCarQueryResponse>(car);
                return response;
            }
        }
    }
}
