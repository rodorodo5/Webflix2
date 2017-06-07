using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using flix.Models.Mongo;
using Microsoft.Ajax.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;


namespace flix.Models
{
    public class MongoMovieDbHelper 
    {
        public List<MongoMovie> nose(string value)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("GoodMovies");
            var coll = db.GetCollection<MongoMovie>("Movie");
            //FilterDefinition<MongoMovie> filter = "{Title : { $regex: '/"+value+"/', $options: 'i' }}";
            //var builder = Builders<MongoMovie>.Filter;
            var filter = Builders<MongoMovie>.Filter.Regex("Title",new BsonRegularExpression("/^"+value+"/"));

            var movies = coll.Find(filter).Limit(10).ToList();

            return movies;
        }
    }

    }




