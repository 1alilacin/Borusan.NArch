using Application.Features.Car.Commands.Create;
using Application.Features.Car.Commands.Delete;
using Application.Features.Car.Commands.Update;
using Application.Features.Car.Queries.GetAll;
using Application.Features.Car.Queries.GetById;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Car.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeleteCarCommand, Domain.Entities.Car>().ReverseMap();
            CreateMap<DeleteCarResponse, Domain.Entities.Car>().ReverseMap();
            CreateMap<UpdateCarCommand, Domain.Entities.Car>().ReverseMap();
            CreateMap<UpdateCarResponse, Domain.Entities.Car>().ReverseMap();
            CreateMap<CreateCarCommand, Domain.Entities.Car>().ReverseMap();
            CreateMap<CreateCarResponse, Domain.Entities.Car>().ReverseMap();
            CreateMap<GetByIdCarQuery, Domain.Entities.Car>().ReverseMap();
            CreateMap<GetByIdCarQueryResponse, Domain.Entities.Car>().ReverseMap();
            CreateMap<GetAllCarQuery, Domain.Entities.Car>().ReverseMap();
            CreateMap<GetAllCarQueryRespponse, Domain.Entities.Car>().ReverseMap();
        }
    }
}
