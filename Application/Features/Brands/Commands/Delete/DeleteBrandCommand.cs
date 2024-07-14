using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>
    {
        public Guid Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            private readonly IMapper mapper;
            private readonly IBrandRepository repository;

            public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }
            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand command, CancellationToken cancellationToken)
            {
                var brand = await repository.GetByIdAsync(command.Id);
                Brand? deletedBrand = await repository.DeleteAsync(brand);
                DeletedBrandResponse response = mapper.Map<DeletedBrandResponse>(deletedBrand);
                return response;


            }
        }
    }
}
