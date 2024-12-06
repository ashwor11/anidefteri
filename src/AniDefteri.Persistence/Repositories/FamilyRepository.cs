using AniDefteri.Application.Services.Interfaces;
using AniDefteri.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace AniDefteri.Persistence.Repositories;

public class FamilyRepository : EfRepositoryBase<AniDefteriDbContext, Family>, IFamilyRepository
{
    public FamilyRepository(AniDefteriDbContext context) : base(context)
    {
    }
}