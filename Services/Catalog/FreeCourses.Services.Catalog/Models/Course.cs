using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourses.Services.Catalog.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public string? Picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        public Feature? Feature { get; set; }

        [BsonIgnore]
        public Category? Category { get; set; }

        public string? CategoryId { get; set; }

    }
}
