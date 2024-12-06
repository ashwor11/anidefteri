using AniDefteri.Domain.Entities;
using Core.Persistence.Repositories;

namespace AniDefteri.Application.Services.Interfaces
{
    public interface IPersonRepository : IAsyncRepository<Person>, IRepository<Person>
    {
        
    }
}
