using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelD2.Entities
{
    public class Room
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("available")]
        public bool Available { get; set; }

    }
}