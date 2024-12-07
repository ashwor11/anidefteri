using AniDefteri.Application.Features.Families.DTOs;
using AniDefteri.Domain.Entities;
using AutoMapper;

namespace AniDefteri.Application.Features.Families.Profiles;

public class PersonMapping : Profile
{
    public PersonMapping()
    {
        CreateMap<Person, AddedPersonDTO>();
        CreateMap<AddPersonDTO, Person>();
    }
}