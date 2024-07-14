using Application.Features.Brands.Queries.GetById;
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

namespace Application.Features.Fuel.Queries.GetById
{
    public class GetByIdFuelQuery : IRequest<GetByIdFuelQueryResponse>
    {
        public Guid Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdFuelQuery, GetByIdFuelQueryResponse>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository repository;

            public GetByIdQueryHandler(IMapper mapper, IFuelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<GetByIdFuelQueryResponse> Handle(GetByIdFuelQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Fuel fuel = await repository.GetByIdAsync(request.Id);
                GetByIdFuelQueryResponse response = mapper.Map<GetByIdFuelQueryResponse>(fuel);
                return response;
            }
        }
    }
}
