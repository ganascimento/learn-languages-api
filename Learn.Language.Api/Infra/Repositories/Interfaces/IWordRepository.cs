using Learn.Language.Api.Domain.Entities;

namespace Learn.Language.Api.Infra.Repositories.Interfaces;

public interface IWordRepository
{
    Task<List<WordEntity>> GetAllAsync();
    Task<WordEntity> GetByIdAsync(string id);
    Task CreateAsync(WordEntity entity);
    Task UpdateAsync(WordEntity entity);
    Task DeleteAsync(string id);
}