using Application.Repositories.Abstract;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Model.Queries.GetAll
{
    public class GetAllModelQuery : IRequest<List<GetAllModelQueryResponse>>
    {
        public class GetAllModelQueryHandler : IRequestHandler<GetAllModelQuery, List<GetAllModelQueryResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IModelRepository _modelRepository;

            public GetAllModelQueryHandler(IMapper mapper, IModelRepository modelRepository)
            {
                _mapper = mapper;
                _modelRepository = modelRepository;
            }

            public async Task<List<GetAllModelQueryResponse>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
            {
                List<Domain.Entities.Model> models = await _modelRepository.GetAllAsync();
                List<GetAllModelQueryResponse> response = _mapper.Map<List<GetAllModelQueryResponse>>(models);
                return response;
            }
        }
    }
}
