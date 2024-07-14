using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Color.Commands.Create;
using Application.Features.Color.Commands.Delete;
using Application.Features.Color.Commands.Update;
using Application.Features.Color.Queries.GetAll;
using Application.Features.Color.Queries.GetById;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Color.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateColorCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<CreateColorResponse, Domain.Entities.Color>().ReverseMap();
            CreateMap<DeleteColorCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<DeleteColorResponse, Domain.Entities.Color>().ReverseMap();
            CreateMap<UpdateColorResponse, Domain.Entities.Color>().ReverseMap();
            CreateMap<UpdateBrandCommand, Domain.Entities.Color>().ReverseMap();
            CreateMap<GetAllColorQueryResponse, Domain.Entities.Color>().ReverseMap();
            CreateMap<GetAllColorQuery, Domain.Entities.Color>().ReverseMap();
            CreateMap<GetByIdColorQueryResponse, Domain.Entities.Color>().ReverseMap();
            CreateMap<GetByIdColorQuery, Domain.Entities.Color>().ReverseMap();

        }
    }
}
