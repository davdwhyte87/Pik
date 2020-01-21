using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pik.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public float Price { get; set; }

        public string Caption { get; set; }

        public string[] Images { get; set; }

        public string CompanyId { get; set; }

        public string UserId { get; set; }

        public string CreatedAt { get; set; }

    }
}
