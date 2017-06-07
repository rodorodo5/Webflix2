using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace flix.Models.Mongo
{
    public class MongoMovie
    {
        [BsonId]
        public ObjectId id { get; set; }
        public long Id { get; set; }
        [BsonElement]
        public string Title { get; set; }
        public short Year { get; set; }
        public int Length { get; set; }
        public string Sinopsis { get; set; }
        public string Description { get; set; }
        public long Country_Id { get; set; }
        public long Director_Id { get; set; }

        //public string User { get; set; }

        //public Country Country { get; set; }
        //public Director Director { get; set; }
        //public List<Movie> Actors { get; set; }
        //public List<MovieActor> MovieActors { get; set; }
        //public List<Genre> Genres { get; set; }
        //public List<Poster> Posters { get; set; }
        //public List<Trailer> Trailers { get; set; }
    }
}