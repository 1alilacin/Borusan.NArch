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

namespace Application.Features.Model.Commands.Create
{
    public class CreateModelCommand : IRequest<CreateModelResponse>
    {
        public string Name { get; set; }
        public DateTime ModelDate { get; set; }
        public Guid BrandId { get; set; }
        public Guid TransmissionId { get; set; }
        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelResponse>
        {
            private readonly IMapper mapper;
            private readonly IModelRepository repository;

            public CreateModelCommandHandler(IMapper mapper, IModelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<CreateModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Model model = mapper.Map<Domain.Entities.Model>(request);
                var addedBrand = await repository.AddAsync(model);

                CreateModelResponse response = mapper.Map<CreateModelResponse>(addedBrand);
                return response;
            }
        }
    }
}
