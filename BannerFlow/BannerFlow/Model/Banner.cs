using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BannerFlow.Model
{
    public class Banner
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public int BannerId { get; set; }

        public string Html { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}