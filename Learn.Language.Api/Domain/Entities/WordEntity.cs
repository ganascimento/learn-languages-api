using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Learn.Language.Api.Domain.Entities;

public class WordEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? EnglishText { get; set; }
    public bool Learn { get; set; }
    public List<string>? Translations { get; set; }
    public List<string>? Phrases { get; set; }
    public bool IsVerb { get; set; }
    public string? Infinitive { get; set; }
    public string? SimplePast { get; set; }
    public string? PastParticiple { get; set; }
    public string? SoundUrl { get; set; }
}