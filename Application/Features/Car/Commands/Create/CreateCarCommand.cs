using Application.Features.Brands.Commands.Create;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Commands.Create
{
    public class CreateCarCommand : IRequest<CreateCarResponse>
    {
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }
        public Guid ModelId { get; set; }
        public Guid ColorId { get; set; }
        public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarResponse>
        {
            private readonly IMapper mapper;
            private readonly ICarRepository carRepository;

            public CreateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
            {
                this.mapper = mapper;
                this.carRepository = carRepository;
            }

            public async Task<CreateCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Car car = mapper.Map<Domain.Entities.Car>(request);
                var addedBrand = await carRepository.AddAsync(car);
                CreateCarResponse response = mapper.Map<CreateCarResponse>(addedBrand);
                return response;
            }
        }
    }
}
