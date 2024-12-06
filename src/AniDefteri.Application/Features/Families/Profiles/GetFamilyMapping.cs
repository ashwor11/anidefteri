using AutoMapper;
using AniDefteri.Domain.Entities;
using AniDefteri.Application.Features.Families.DTOs;

namespace AniDefteri.Application.Features.Families.Profiles
{
    public class GetFamilyMapping : Profile
    {
        public GetFamilyMapping()
        {
            CreateMap<Family, GetFamilyResponseDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<Relationship, RelationshipDto>()
                .ConstructUsing(src => new RelationshipDto
                {
                    Id = src.Id,
                    PersonId = src.PersonId,
                    RelatedPersonId = src.RelatedPersonId,
                    RelationType = src.RelationshipType.ToString()
                });
        }
        
    }
}

