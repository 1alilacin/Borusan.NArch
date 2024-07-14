using Application.Features.Brands.Commands.Delete;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Commands.Delete
{
    public class DeleteCarCommand : IRequest<DeleteCarResponse>
    {
        public Guid Id { get; set; }
        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarResponse>
        {
            private readonly IMapper mapper;
            private readonly ICarRepository carRepository;

            public DeleteCarCommandHandler(IMapper mapper, ICarRepository carRepository)
            {
                this.mapper = mapper;
                this.carRepository = carRepository;
            }

            public async Task<DeleteCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var car = await carRepository.GetByIdAsync(request.Id);
                Domain.Entities.Car? deletedCar = await carRepository.DeleteAsync(car);
                DeleteCarResponse response = mapper.Map<DeleteCarResponse>(deletedCar);
                return response;
            }
        }
    }
}
