using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
namespace FreeCourses.Services.Catalog.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int UnitsOfStock { get; set; }
        [BsonRepresentation(BsonType.DateTime)]

        public DateTime CreatedDate { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        [BsonIgnore]
        public IEnumerable<Color>? Color { get; set; }
        [BsonIgnore]
        public IEnumerable<Popularity>? Popularity { get; set; }
        public string PopularityId { get; set; }
        [BsonElement(elementName: "ColorIds")]
        public IEnumerable<string> ColorIds { get; set; }
        [BsonIgnore]
        public IEnumerable<Size>? Size { get; set; }

        [BsonElement(elementName: "SizeIds")]
        public IEnumerable<string> SizeIds { get; set; }
        [BsonIgnore]
        public For? For { get; set; }
        public string ForId { get; set; }
        [BsonIgnore]
        public Category? Category { get; set; }
        public string? CategoryId { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
