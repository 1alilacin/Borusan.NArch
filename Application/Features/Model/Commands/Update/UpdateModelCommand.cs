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

namespace Application.Features.Model.Commands.Update
{
    public class UpdateModelCommand : IRequest<UpdateModelResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ModelDate { get; set; }
        public Guid BrandId { get; set; }
        public Guid TransmissionId { get; set; }
        public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdateModelResponse>
        {
            private readonly IMapper mapper;
            private readonly IModelRepository modelRepository;

            public UpdateModelCommandHandler(IMapper mapper, IModelRepository modelRepository)
            {
                this.mapper = mapper;
                this.modelRepository = modelRepository;
            }

            public async Task<UpdateModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Model? model = await modelRepository.GetByIdAsync(request.Id);
                if (model == null)
                    throw new Exception("Güncellenmeye çalıştığınız model bulunamadı");
                mapper.Map(request, model);
                await modelRepository.UpdateAsync(model);
                UpdateModelResponse response = mapper.Map<UpdateModelResponse>(model);
                return response;
            }
        }
    }
}
