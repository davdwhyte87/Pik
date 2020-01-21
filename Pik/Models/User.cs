using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pik.Models
{
    public class User
    {
        public User()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        //public string Password { get; set; }

        public string DateTime { get; set; }

        public string Image { get; set; }

        public string Location { get; set; }

        public bool IsModel { get; set; }
    }
}