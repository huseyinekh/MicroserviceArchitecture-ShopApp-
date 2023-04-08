using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourses.Services.Catalog.Models
{
    public class Size
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string SizeName { get; set; } = null!;
    }
}
