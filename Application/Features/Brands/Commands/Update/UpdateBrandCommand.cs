using Application.Features.Brands.Commands.Delete;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }// güncellemesini istediğimiz alanlar 
        public class UpdateBrandCommanHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public UpdateBrandCommanHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand updateBrandCommand, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetByIdAsync(updateBrandCommand.Id);
                if (brand == null)
                    throw new Exception("Güncellenmeye çalıştığınız marka bulunamadı");
                _mapper.Map(updateBrandCommand, brand);
                await _brandRepository.UpdateAsync(brand);
                UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);
                return response;
            }
        }
    }
}
