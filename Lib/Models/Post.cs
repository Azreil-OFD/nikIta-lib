using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lib.Models
{
    public class Post
    {
        [BsonIgnore]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CreatedAt { get; set; }
        public string OwnerId { get; set; }
        public bool Visible { get; set; }
        public int Solar { get; set; }
        public List<string> Images { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Like { get; set; }
    }
}