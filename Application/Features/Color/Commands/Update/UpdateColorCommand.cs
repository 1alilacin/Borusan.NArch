using Application.Repositories.Abstract;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Commands.Update
{
    public class UpdateColorCommand : IRequest<UpdateColorResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public class UpdateColorcommandHandler : IRequestHandler<UpdateColorCommand, UpdateColorResponse>
        {
            private readonly IMapper mapper;
            private readonly IColorRepository colorRepository;

            public UpdateColorcommandHandler(IMapper mapper, IColorRepository colorRepository)
            {
                this.mapper = mapper;
                this.colorRepository = colorRepository;
            }

            public async Task<UpdateColorResponse> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                var color = await colorRepository.GetByIdAsync(request.Id);
                if (color == null)
                    throw new Exception("Güncellemeye çalıştığınız renk bulunamadı");
                mapper.Map(request, color);
                await colorRepository.UpdateAsync(color);
                UpdateColorResponse response = mapper.Map<UpdateColorResponse>(color);
                return response;

            }
        }
    }
}
