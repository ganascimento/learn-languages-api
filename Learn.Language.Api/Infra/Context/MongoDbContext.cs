using Learn.Language.Api.Domain.Entities;
using MongoDB.Driver;

namespace Learn.Language.Api.Infra.Context;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration["Mongo:ConnectionString"]);
        _database = mongoClient.GetDatabase(configuration["Mongo:Database"]);
    }

    public IMongoCollection<WordEntity> Word
    {
        get
        {
            return _database.GetCollection<WordEntity>("Word");
        }
    }
}