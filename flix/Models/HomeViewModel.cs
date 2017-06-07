using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Genre> LGenres { get; set; }
        public Genre Genre { get; set; }

        public IEnumerable<Actor> LActors { get; set; }
        public Actor Actor { get; set; }

        public Poster Poster { get; set; }
        public IEnumerable<Poster> LPoster { get; set; }

        public Movie Movie { get; set; }
        public IEnumerable<Movie> LMovie { get; set; }

        public GetLastReviews GetLastReviews { get; set; }
        public IEnumerable<GetLastReviews> LGetLastReviews { get; set; }

        public ReviewList ReviewList { get; set; }
        public IEnumerable<ReviewList> LReviewList { get; set; }

        public MostPopularMovie MostPopularMovie { get; set; }
        public IEnumerable<MostPopularMovie> LMostPopularMovies { get; set; }

        public GetTopUserReviewers GetTopUserReviewers { get; set; }
        public IEnumerable<GetTopUserReviewers> LGetTopUserReviewerses { get; set; }

        
        
    }

}