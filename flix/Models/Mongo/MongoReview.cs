using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace flix.Models.Mongo
{
    public class MongoReview
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public long Id { get; set; }
        public string Comment { get; set; }
        public int Rank { get; set; }
        public bool Watched { get; set; }
        public bool Wished { get; set; }
        public long Movie_Id { get; set; }
        public long User_Id { get; set; }
        public DateTime Date { get; set; }
    }
}