using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class ProfileViewModel
    {
        public List<Review> LReviews { get; set; }
        public List<Movie> LMovie { get; set; }
        public List<Poster> LPoster { get; set; }
    }
}