using AniDefteri.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;

namespace AniDefteri.Application.Features.Families.Rules;

public class FamilyBusinessRules
{
    public void FamilyMustExist(Family? family)
    {
        if (family == null) throw new BusinessException("Family does not exist");
    }
}