using Application.Features.Brands.Queries.GetAll;
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

namespace Application.Features.Fuel.Queries.GetAll
{
    public class GetAllFuelQuery : IRequest<List<GetAllFuelQueryResponse>>
    {
        public class GetAllFuelQueryHandler : IRequestHandler<GetAllFuelQuery, List<GetAllFuelQueryResponse>>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository repository;

            public GetAllFuelQueryHandler(IMapper mapper, IFuelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<List<GetAllFuelQueryResponse>> Handle(GetAllFuelQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.Fuel> fuels = await repository.GetAllAsync();

                List<GetAllFuelQueryResponse> response = mapper.Map<List<GetAllFuelQueryResponse>>(fuels);
                return response;
            }
        }
    }
}
