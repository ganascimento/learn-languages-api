using Learn.Language.Api.Domain.Entities;
using Learn.Language.Api.Infra.Context;
using Learn.Language.Api.Infra.Repositories.Interfaces;
using MongoDB.Driver;

namespace Learn.Language.Api.Infra.Repositories;

public class WordRepository : IWordRepository
{
    private readonly MongoDbContext _context;

    public WordRepository(MongoDbContext context)
    {
        _context = context;
    }

    public Task<List<WordEntity>> GetAllAsync()
    {
        return _context.Word.Find(_ => true).ToListAsync();
    }

    public Task<WordEntity> GetByIdAsync(string id)
    {
        return _context.Word.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task CreateAsync(WordEntity entity)
    {
        return _context.Word.InsertOneAsync(entity);
    }

    public Task UpdateAsync(WordEntity entity)
    {
        return _context.Word.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public Task DeleteAsync(string id)
    {
        return _context.Word.DeleteOneAsync(x => x.Id == id);
    }
}