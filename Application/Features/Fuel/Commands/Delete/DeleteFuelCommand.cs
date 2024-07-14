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

namespace Application.Features.Fuel.Commands.Delete
{
    public class DeleteFuelCommand : IRequest<DeleteFuelResponse>
    {
        public Guid Id { get; set; }
        public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeleteFuelResponse>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository repository;

            public DeleteFuelCommandHandler(IMapper mapper, IFuelRepository repository)
            {
                this.mapper = mapper;
                this.repository = repository;
            }

            public async Task<DeleteFuelResponse> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var fuel = await repository.GetByIdAsync(request.Id);
                Domain.Entities.Fuel? deletedFuel = await repository.DeleteAsync(fuel);
                DeleteFuelResponse response = mapper.Map<DeleteFuelResponse>(deletedFuel);
                return response;
            }
        }
    }
}
