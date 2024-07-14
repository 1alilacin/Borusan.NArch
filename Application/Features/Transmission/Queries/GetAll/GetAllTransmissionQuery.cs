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

namespace Application.Features.Transmission.Queries.GetAll
{
    public class GetAllTransmissionQuery : IRequest<List<GetAllTranmissionQueryResponse>>
    {
        public class GetAllTranmissionQueryHandler : IRequestHandler<GetAllTransmissionQuery, List<GetAllTranmissionQueryResponse>>
        {
            private readonly IMapper mapper;
            private readonly ITransmissionRepository repository;

            public GetAllTranmissionQueryHandler(IMapper mapper, ITransmissionRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<List<GetAllTranmissionQueryResponse>> Handle(GetAllTransmissionQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.Transmission> brands = await repository.GetAllAsync();

                List<GetAllTranmissionQueryResponse> response = mapper.Map<List<GetAllTranmissionQueryResponse>>(brands);
                return response;
            }
        }
    }
}
