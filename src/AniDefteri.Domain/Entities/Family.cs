using Core.Persistence.Repositories;

namespace AniDefteri.Domain.Entities;

public class Family : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Person> Persons { get; set; } = [];

    public void AddPerson(Person person)
    {
        Persons.Add(person);
    }

    

    public void CreateRelation(Person person1, Person person2, RelationshipType relationshipType)
    {
        person1.AddRelation(new Relationship(person1,person2, relationshipType));
        RelationshipType reverseRelation = RelationshipHelper.GetReverseRelationship(relationshipType);
        person2.AddRelation(new Relationship(person2,person1, reverseRelation));
    }
}