using Application.Features.Brands.Commands.Update;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Commands.Update
{
    public class UpdateCarCommand : IRequest<UpdateCarResponse>
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }
        public Guid ModelId { get; set; }
        public Guid ColorId { get; set; }
        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarResponse>
        {
            private readonly IMapper mapper;
            private readonly ICarRepository carRepository;

            public UpdateCarCommandHandler(IMapper mapper, ICarRepository carRepository)
            {
                this.mapper = mapper;
                this.carRepository = carRepository;
            }

            public async Task<UpdateCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Car? car = await carRepository.GetByIdAsync(request.Id);
                if (car == null)
                    throw new Exception("Güncellenmeye çalıştığınız araba bulunamadı");
                mapper.Map(request, car);
                await carRepository.UpdateAsync(car);
                UpdateCarResponse response = mapper.Map<UpdateCarResponse>(car);
                return response;
            }
        }
    }
}
