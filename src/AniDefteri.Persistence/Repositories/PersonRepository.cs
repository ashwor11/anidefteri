using AniDefteri.Application.Services.Interfaces;
using AniDefteri.Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace AniDefteri.Persistence.Repositories;

public class PersonRepository : EfRepositoryBase<AniDefteriDbContext, Person>,  IPersonRepository
{
    public PersonRepository(AniDefteriDbContext context) : base(context)
    {
    }
}