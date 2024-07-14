using Application.Features.Transmission.Commands.Create;
using Application.Features.Transmission.Commands.Delete;
using Application.Features.Transmission.Commands.Update;
using Application.Features.Transmission.Queries.GetAll;
using Application.Features.Transmission.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmission.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTransmissionCommand, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<CreateTransmissionResponse, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<DeleteTranmissionResponse, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<DeleteTransmissionCommand, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<UpdateTranmissionCommand, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<UpdateTranmissionResponse, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<GetByIdTranmissionQueryResponse, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<GetByIdTransmissionQuery, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<GetAllTranmissionQueryResponse, Domain.Entities.Transmission>().ReverseMap();
            CreateMap<GetAllTransmissionQuery, Domain.Entities.Transmission>().ReverseMap();
        }
    }
}
