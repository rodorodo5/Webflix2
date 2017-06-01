using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class Review
    {

        public long Id { get; set; }
        public string Comment { get; set; }
        public short Rank { get; set; }
        public bool Watched { get; set; }
        public bool Wished { get; set; }
        public DateTime Date { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }

         public GetLastReviews GetLastReviews { get; set; }
        public IEnumerable<GetLastReviews> LGetLastReviews { get; set; }

        public ReviewList ReviewList { get; set; }
        public IEnumerable<ReviewList> LReviewList { get; set; }
        //public long Id { get; set; }
        //public string Comment { get; set; }
        //public short rank { get; set; }
        //public DateTime Date { get; set; }
        //public Movie Movie { get; set; }
        //public User User { get; set; }

    }
}