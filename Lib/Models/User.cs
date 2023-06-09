using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lib.Models
{
	public class User
	{
        [BsonIgnore]
        public string Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}

