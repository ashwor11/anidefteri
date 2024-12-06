using Core.Persistence.Repositories;

namespace AniDefteri.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int FamilyId { get; set; }
        public List<Relationship> Relationships { get; set; } = new();
        public Family Family { get; set; }


        public Person()
        {
        }
        public void AddRelation(Relationship relationship)
        {
            Relationships.Add(relationship);
        }

    }
}
