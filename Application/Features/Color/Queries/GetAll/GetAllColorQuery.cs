using Application.Repositories.Abstract;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Queries.GetAll
{
    public class GetAllColorQuery : IRequest<List<GetAllColorQueryResponse>>
    {
        public class GelAllColorQueryHandler : IRequestHandler<GetAllColorQuery, List<GetAllColorQueryResponse>>
        {
            private readonly IMapper mapper;
            private readonly IColorRepository colorRepository;

            public GelAllColorQueryHandler(IMapper mapper, IColorRepository colorRepository)
            {
                this.mapper = mapper;
                this.colorRepository = colorRepository;
            }

            public async Task<List<GetAllColorQueryResponse>> Handle(GetAllColorQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.Color> colors = await colorRepository.GetAllAsync();
                List<GetAllColorQueryResponse> response = mapper.Map<List<GetAllColorQueryResponse>>(colors);
                return response;

            }
        }
    }
}
