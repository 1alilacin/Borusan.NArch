using Application.Repositories.Abstract;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Model.Queries.GetById
{
    public class GetByIdModelQuery : IRequest<GetByIdModelQueryResponse>
    {
        public Guid Id { get; set; }
        public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery, GetByIdModelQueryResponse>
        {
            private readonly IMapper mapper;
            private readonly IModelRepository repository;

            public GetByIdModelQueryHandler(IMapper mapper, IModelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<GetByIdModelQueryResponse> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.Model model = await repository.GetByIdAsync(request.Id);
                GetByIdModelQueryResponse response = mapper.Map<GetByIdModelQueryResponse>(model);
                return response;

            }
        }
    }
}
