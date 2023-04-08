using FreeCourses.Services.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourses.Services.Catalog.Dtos.Blog
{
    public class Blog
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? AuthorId { get; set; }

        [BsonIgnore]
        public Author? Author { get; set; }

    }
}
