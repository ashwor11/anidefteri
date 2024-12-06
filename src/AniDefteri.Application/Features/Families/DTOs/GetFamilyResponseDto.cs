namespace AniDefteri.Application.Features.Families.DTOs;

public class GetFamilyResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<PersonDto> Persons { get; set; }
}

public class PersonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public List<RelationshipDto> Relationships { get; set; }

}

public class RelationshipDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
    public string RelationType { get; set; }
}