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

namespace Application.Features.Color.Queries.GetById
{
    public class GetByIdColorQuery : IRequest<GetByIdColorQueryResponse>
    {
        public Guid Id { get; set; }
        public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQuery, GetByIdColorQueryResponse>
        {
            private readonly IMapper mapper;
            private readonly IColorRepository colorRepository;

            public GetByIdColorQueryHandler(IMapper mapper, IColorRepository colorRepository)
            {
                this.mapper = mapper;
                this.colorRepository = colorRepository;
            }

            public async Task<GetByIdColorQueryResponse> Handle(GetByIdColorQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Color color = await colorRepository.GetByIdAsync(request.Id);
                GetByIdColorQueryResponse response = mapper.Map<GetByIdColorQueryResponse>(color);
                return response;
            }
        }
    }
}
