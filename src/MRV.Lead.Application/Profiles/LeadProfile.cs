using AutoMapper;
using MRV.Lead.Application.Lead.Command;
using MRV.Lead.Application.QueryServices.Dtos;
using MRV.Lead.Domain.Models;

namespace MRV.Lead.Application.Profiles;

public class LeadProfile : Profile
{
    public LeadProfile()
    {
        CreateMap<LeadCreateCommand, LeadModel>();
        CreateMap<LeadModel, LeadDto>().ReverseMap();
    }
}