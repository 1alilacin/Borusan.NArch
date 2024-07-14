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

namespace Application.Features.Transmission.Queries.GetById
{
    public class GetByIdTransmissionQuery : IRequest<GetByIdTranmissionQueryResponse>
    {
        public Guid Id { get; set; }
        public class GetByIdTransmissionQueryHandler : IRequestHandler<GetByIdTransmissionQuery, GetByIdTranmissionQueryResponse>
        {
            private readonly IMapper mapper;
            private readonly ITransmissionRepository repository;

            public GetByIdTransmissionQueryHandler(IMapper mapper, ITransmissionRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<GetByIdTranmissionQueryResponse> Handle(GetByIdTransmissionQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Transmission transmission = await repository.GetByIdAsync(request.Id);
                GetByIdTranmissionQueryResponse response = mapper.Map<GetByIdTranmissionQueryResponse>(transmission);
                return response;
            }
        }
    }
}
