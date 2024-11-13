using Learn.Language.Api.Domain.Entities;
using Learn.Language.Api.Infra.Repositories.Interfaces;
using Learn.Language.Api.Services.Interfaces;

namespace Learn.Language.Api.Services;

public class WordService : IWordService
{
    private readonly IWordRepository _wordRepository;

    public WordService(IWordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public async Task<List<WordEntity>> GetAllAsync()
    {
        var words = await _wordRepository.GetAllAsync();
        return words.OrderBy(x => x.EnglishText).ToList();
    }

    public Task<WordEntity> GetByIdAsync(string id)
    {
        return _wordRepository.GetByIdAsync(id);
    }

    public Task CreateAsync(WordEntity entity)
    {
        return _wordRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(WordEntity entity)
    {
        if (string.IsNullOrEmpty(entity.Id))
            throw new InvalidDataException("Invalid parameter!");

        var word = await _wordRepository.GetByIdAsync(entity.Id);
        if (word == null || string.IsNullOrEmpty(word.Id))
            throw new InvalidDataException("Invalid parameter!");

        await _wordRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new InvalidDataException("Invalid parameter!");

        var word = await _wordRepository.GetByIdAsync(id);
        if (word == null || string.IsNullOrEmpty(word.Id))
            throw new InvalidDataException("Invalid parameter!");

        await _wordRepository.DeleteAsync(word.Id);
    }
}