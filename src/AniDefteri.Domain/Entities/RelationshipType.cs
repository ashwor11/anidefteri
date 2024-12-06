namespace AniDefteri.Domain.Entities;

public enum RelationshipType
{
    PARENT,
    CHILD,
    SPOUSE,
    SIBLING,
    UNKNOWN
}

public static class RelationshipHelper
{
    private static readonly Dictionary<RelationshipType, RelationshipType> ReverseRelationships = new()
    {
        { RelationshipType.PARENT, RelationshipType.CHILD },
        { RelationshipType.CHILD, RelationshipType.PARENT },
        { RelationshipType.SPOUSE, RelationshipType.SPOUSE },
        { RelationshipType.SIBLING, RelationshipType.SIBLING },
        { RelationshipType.UNKNOWN, RelationshipType.UNKNOWN }
    };

    public static RelationshipType GetReverseRelationship(RelationshipType relationshipType)
    {
        return ReverseRelationships.TryGetValue(relationshipType, out var reverse)
            ? reverse
            : RelationshipType.UNKNOWN;
    }
}