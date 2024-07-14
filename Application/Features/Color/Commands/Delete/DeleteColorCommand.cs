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

namespace Application.Features.Color.Commands.Delete
{
    public class DeleteColorCommand : IRequest<DeleteColorResponse>
    {
        public Guid Id { get; set; }
        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeleteColorResponse>
        {
            private readonly IMapper mapper;
            private readonly IColorRepository colorRepository;

            public DeleteColorCommandHandler(IMapper mapper, IColorRepository colorRepository)
            {
                this.mapper = mapper;
                this.colorRepository = colorRepository;
            }

            public async Task<DeleteColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                var color = await colorRepository.GetByIdAsync(request.Id);
                Domain.Entities.Color? deletedColor = await colorRepository.DeleteAsync(color);
                DeleteColorResponse response = mapper.Map<DeleteColorResponse>(deletedColor);
                return response;
            }
        }
    }
}
