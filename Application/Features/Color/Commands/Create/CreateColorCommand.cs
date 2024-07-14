using Application.Repositories.Abstract;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Commands.Create
{
    public class CreateColorCommand : IRequest<CreateColorResponse>
    {
        public string Name { get; set; }
        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreateColorResponse>
        {
            private readonly IMapper mapper;
            private readonly IColorRepository colorRepository;

            public CreateColorCommandHandler(IMapper mapper, IColorRepository colorRepository)
            {
                this.mapper = mapper;
                this.colorRepository = colorRepository;
            }

            public async Task<CreateColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Color color = mapper.Map<Domain.Entities.Color>(request);
                var addedColor = await colorRepository.AddAsync(color);
                CreateColorResponse response = mapper.Map<CreateColorResponse>(addedColor);
                return response;
            }
        }
    }
}
