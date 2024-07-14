using Application.Features.Brands.Commands.Update;
using Application.Repositories.Abstract;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Commands.Update
{
    public class UpdateFuelCommand : IRequest<UpdateFuelResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdateFuelResponse>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository repository;

            public UpdateFuelCommandHandler(IMapper mapper, IFuelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<UpdateFuelResponse> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Fuel? fuel = await repository.GetByIdAsync(request.Id);
                if (fuel == null)
                    throw new Exception("Güncellenmeye çalıştığınız marka bulunamadı");
                mapper.Map(request, fuel);
                await repository.UpdateAsync(fuel);
                UpdateFuelResponse response = mapper.Map<UpdateFuelResponse>(fuel);
                return response;
            }
        }
    }
}
