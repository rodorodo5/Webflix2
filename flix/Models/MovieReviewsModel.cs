using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using flix.Models.Mongo;

namespace flix.Models
{
    public class MovieReviewsModel
    {
        public List<MongoReview> LReviews { get; set; }
        public List<Movie> Movie;

        public List<MovieActor> MovieActors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Poster> Posters { get; set; }
        public List<Trailer> Trailers { get; set; }
       
    }
}