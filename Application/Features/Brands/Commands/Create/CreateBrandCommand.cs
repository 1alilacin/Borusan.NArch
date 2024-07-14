using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    //unit--fonksiyonda void ne ise request de o 
    public class CreateBrandCommand : IRequest<CreatedBrandResponse>
    {
        //komutun işlevini yerine getirmesi için alması gereken argümanlar
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            //gerekli bağımlılıkları içerir
            private readonly IMapper mapper;
            private readonly IBrandRepository brandRepository;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                this.brandRepository = brandRepository;
                this.mapper = mapper;
            }

            public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                // ilgili request ile istediğinizi yapabilirsiniz.
                //Brand brands = new Brand()
                //{
                //    Name = request.Name,
                //};
                Brand brand = mapper.Map<Brand>(request);
                var addedBrand = await brandRepository.AddAsync(brand);
                //CreatedBrandResponse response = new CreatedBrandResponse()
                //{
                //    Id = addedBrand.Id,
                //    Name = addedBrand.Name,
                //};
                CreatedBrandResponse response = mapper.Map<CreatedBrandResponse>(addedBrand);
                return response;
            }
        }
    }
}
