using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace flix.Models.Mongo
{
    public class MongoGenre
    {
        public ObjectId _id { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}