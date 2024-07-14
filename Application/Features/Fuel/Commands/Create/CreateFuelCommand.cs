using Application.Features.Color.Commands.Create;
using Application.Repositories.Abstract;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Commands.Create
{
    public class CreateFuelCommand : IRequest<CreateFuelResponse>
    {
        public string Name { get; set; }
        public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreateFuelResponse>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository repository;

            public CreateFuelCommandHandler(IMapper mapper, IFuelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<CreateFuelResponse> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Fuel fuel = mapper.Map<Domain.Entities.Fuel>(request);
                var addedColor = await repository.AddAsync(fuel);
                CreateFuelResponse response = mapper.Map<CreateFuelResponse>(addedColor);
                return response;
            }
        }
    }
}
