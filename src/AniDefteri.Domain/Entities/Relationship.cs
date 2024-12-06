using Core.Persistence.Repositories;

namespace AniDefteri.Domain.Entities
{
    
    public class Relationship : Entity
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        
        public Person Person { get; set; }
        public Person RelatedPerson { get; set; }
        public RelationshipType RelationshipType { get; set; }

        public Relationship()
        {
            
        }
        public Relationship(Person person,Person relatedPerson, RelationshipType relationshipType)
        {
            Person = person;
            RelatedPerson = relatedPerson;
            RelationshipType = relationshipType;
        }
    }
}
