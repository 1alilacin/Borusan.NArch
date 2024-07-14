using Application.Features.Brands.Commands.Delete;
using Application.Repositories.Abstract;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Model.Commands.Delete
{
    public class DeleteModelCommand : IRequest<DeleteModelResponse>
    {
        public Guid Id { get; set; }
        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeleteModelResponse>
        {
            private readonly IMapper mapper;
            private readonly IModelRepository repository;

            public DeleteModelCommandHandler(IMapper mapper, IModelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<DeleteModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var model = await repository.GetByIdAsync(request.Id);
                Domain.Entities.Model? deletedModel = await repository.DeleteAsync(model);
                DeleteModelResponse response = mapper.Map<DeleteModelResponse>(deletedModel);
                return response;
            }
        }
    }
}
