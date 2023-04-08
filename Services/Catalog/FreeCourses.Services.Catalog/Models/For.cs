﻿using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourses.Services.Catalog.Models
{
    public class For
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
