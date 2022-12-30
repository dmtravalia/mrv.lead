using MRV.Lead.Domain.Models;
using AutoMapper;
using MRV.Lead.Application.Contact.Command;
using MRV.Lead.Application.QueryServices.Dtos;

namespace MRV.Lead.Application.Profiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactCreateCommand, ContactModel>().ReverseMap();
        CreateMap<ContactUpdateCommand, ContactModel>().ReverseMap();
        CreateMap<ContactModel, ContactDto>().ReverseMap();
    }
}