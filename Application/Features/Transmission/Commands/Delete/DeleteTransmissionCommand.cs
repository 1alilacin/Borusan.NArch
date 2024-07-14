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

namespace Application.Features.Transmission.Commands.Delete
{
    public class DeleteTransmissionCommand : IRequest<DeleteTranmissionResponse>
    {
        public Guid Id { get; set; }
        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeleteTranmissionResponse>
        {
            private readonly IMapper mapper;
            private readonly ITransmissionRepository transmissionRepository;

            public DeleteTransmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
            {
                this.mapper = mapper;
                this.transmissionRepository = transmissionRepository;
            }

            public async Task<DeleteTranmissionResponse> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {
                var transmission = await transmissionRepository.GetByIdAsync(request.Id);
                Domain.Entities.Transmission? deletedBrand = await transmissionRepository.DeleteAsync(transmission);
                DeleteTranmissionResponse response = mapper.Map<DeleteTranmissionResponse>(deletedBrand);
                return response;
            }
        }
    }
}
