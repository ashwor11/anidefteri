using AniDefteri.Domain.Entities;
using Core.Persistence.Repositories;

namespace AniDefteri.Application.Services.Interfaces;

public interface IFamilyRepository : IRepository<Family>, IAsyncRepository<Family>
{
    
}