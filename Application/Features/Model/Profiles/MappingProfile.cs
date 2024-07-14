using Application.Features.Model.Commands.Create;
using Application.Features.Model.Commands.Delete;
using Application.Features.Model.Commands.Update;
using Application.Features.Model.Queries.GetAll;
using Application.Features.Model.Queries.GetById;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Model.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateModelCommand, Domain.Entities.Model>().ReverseMap();
            CreateMap<CreateModelResponse, Domain.Entities.Model>().ReverseMap();
            CreateMap<UpdateModelCommand, Domain.Entities.Model>().ReverseMap();
            CreateMap<UpdateModelResponse, Domain.Entities.Model>().ReverseMap();
            CreateMap<DeleteModelCommand, Domain.Entities.Model>().ReverseMap();
            CreateMap<DeleteModelResponse, Domain.Entities.Model>().ReverseMap();
            CreateMap<GetByIdModelQuery, Domain.Entities.Model>().ReverseMap();
            CreateMap<GetByIdModelQueryResponse, Domain.Entities.Model>().ReverseMap();
            CreateMap<GetAllModelQuery, Domain.Entities.Model>().ReverseMap();
            CreateMap<GetAllModelQueryResponse, Domain.Entities.Model>().ReverseMap();
        }
    }
}
