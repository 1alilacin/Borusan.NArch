using Application.Features.Brands.Commands.Update;
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

namespace Application.Features.Transmission.Commands.Update
{
    public class UpdateTranmissionCommand : IRequest<UpdateTranmissionResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public class UpdateTranmissionCommandHandler : IRequestHandler<UpdateTranmissionCommand, UpdateTranmissionResponse>
        {
            private readonly IMapper mapper;
            private readonly ITransmissionRepository transmissionRepository;

            public UpdateTranmissionCommandHandler(IMapper mapper, ITransmissionRepository transmissionRepository)
            {
                this.mapper = mapper;
                this.transmissionRepository = transmissionRepository;
            }

            public async Task<UpdateTranmissionResponse> Handle(UpdateTranmissionCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Transmission? transmission = await transmissionRepository.GetByIdAsync(request.Id);
                if (transmission == null)
                    throw new Exception("Güncellenmeye çalıştığınız marka bulunamadı");
                mapper.Map(request, transmission);
                await transmissionRepository.UpdateAsync(transmission);
                UpdateTranmissionResponse response = mapper.Map<UpdateTranmissionResponse>(transmission);
                return response;
            }
        }
    }
}
