using Application.Features.Fuel.Commands.Create;
using Application.Features.Fuel.Commands.Delete;
using Application.Features.Fuel.Commands.Update;
using Application.Features.Fuel.Queries.GetAll;
using Application.Features.Fuel.Queries.GetById;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuel.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFuelResponse, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<CreateFuelCommand, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<DeleteFuelCommand, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<DeleteFuelResponse, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<UpdateFuelCommand, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<UpdateFuelResponse, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<GetByIdFuelQuery, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<GetByIdFuelQueryResponse, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<GetAllFuelQueryResponse, Domain.Entities.Fuel>().ReverseMap();
            CreateMap<GetAllFuelQuery, Domain.Entities.Fuel>().ReverseMap();
        }
    }
}
