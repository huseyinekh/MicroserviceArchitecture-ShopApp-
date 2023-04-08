using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourses.Services.Catalog.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subjects { get; set; }
        public string MessageText { get; set; }

    }
}
