namespace AniDefteri.Application.Features.Families.DTOs;

public class AddPersonDTO
{
    public string Name { get; set; }
    public string? Biography { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public int FamilyId { get; set; }
}