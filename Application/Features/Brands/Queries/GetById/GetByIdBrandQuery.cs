using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetById
{
    public class GetByIdBrandQuery : IRequest<GetByIdBrandItemResponse>
    {
        public Guid Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdBrandQuery, GetByIdBrandItemResponse>
        {
            private readonly IBrandRepository brandRepository;
            private readonly IMapper mapper;

            public GetByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                this.brandRepository = brandRepository;
                this.mapper = mapper;
            }

            public async Task<GetByIdBrandItemResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand brand = await brandRepository.GetByIdAsync(request.Id);
                GetByIdBrandItemResponse response = mapper.Map<GetByIdBrandItemResponse>(brand);
                return response;
            }
        }
    }
}
