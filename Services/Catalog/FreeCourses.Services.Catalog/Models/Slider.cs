using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourses.Services.Catalog.Models
{
    public class Slider
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

    }
}
