using Application.Features.Brands.Commands.Create;
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

namespace Application.Features.Transmission.Commands.Create
{
    public class CreateTransmissionCommand : IRequest<CreateTransmissionResponse>
    {
        public string Name { get; set; }
        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreateTransmissionResponse>
        {
            private readonly IMapper mapper;
            private readonly ITransmissionRepository transmissionRepository;

            public CreateTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
            {
                this.mapper = mapper;
                this.transmissionRepository = transmissionRepository;
            }

            public async Task<CreateTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Transmission transmission = mapper.Map<Domain.Entities.Transmission>(request);
                var addedBrand = await transmissionRepository.AddAsync(transmission);
                CreateTransmissionResponse response = mapper.Map<CreateTransmissionResponse>(addedBrand);
                return response;
            }
        }
    }
}
