using AutoMapper;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Queries.GetAll
{
    public class GetAllCarQuery : IRequest<List<GetAllCarQueryRespponse>>
    {
        public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, List<GetAllCarQueryRespponse>>
        {
            private readonly IMapper mapper;
            private readonly ICarRepository carRepository;

            public GetAllCarQueryHandler(IMapper mapper, ICarRepository carRepository)
            {
                this.mapper = mapper;
                this.carRepository = carRepository;
            }

            public async Task<List<GetAllCarQueryRespponse>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.Car> car = await carRepository.GetAllAsync();
                List<GetAllCarQueryRespponse> responses = mapper.Map<List<GetAllCarQueryRespponse>>(car);
                return responses;
            }
        }
    }
}
