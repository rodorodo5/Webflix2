using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using flix.Models.Mongo;
using Microsoft.Ajax.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;


namespace flix.Models
{
    public class MongoMovieDbHelper
    {
        private readonly MongoClient _client = new MongoClient("mongodb://localhost:27017");
     
        public List<MongoMovie> SearchMovieName(string value,string option)
        {
            List<MongoMovie> movies =new List<MongoMovie>();

            try
            {
                var db = _client.GetDatabase("GoodMovies");
                if (option == "Pelicula")
                {
                    var colection = db.GetCollection<MongoMovie>("Movie");
                    var filter =Builders<MongoMovie>.Filter.Regex("Title", new BsonRegularExpression("/^" + value + "/"));
                    movies = colection.Find(filter).Limit(10).ToList();
                }
                else
                {
                    var colection = db.GetCollection<MongoMovie>("Genre");
                    var filter = Builders<MongoMovie>.Filter.Regex("Name", new BsonRegularExpression("/^" + value + "/"));
                    movies = colection.Find(filter).Limit(10).ToList();
                }
           
               
            }
            catch (Exception e)
            {
                //Cambiar a una vista 
                Console.WriteLine(e.Message);
            }
            return movies;
        }

        public void InsertOne(string dbname, string collection, string jsontext)
        {
            try
            {
                var database = _client.GetDatabase(dbname);
                var colection = database.GetCollection<BsonDocument>(collection);
                var document = BsonSerializer.Deserialize<BsonDocument>(jsontext);
                colection.InsertOneAsync(document);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<MongoReview> GetReviews(int Id)
        {
            List<MongoReview> review = new List<MongoReview>();
         
                var database = _client.GetDatabase("GoodMovies");
                var colection = database.GetCollection<MongoReview>("Review");
                review = colection.Find(r => r.Movie_Id==Id).Limit(10).ToList();
          
            
            return review;
        }
    }
}




