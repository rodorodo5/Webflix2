using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class GetTopUserReviewers
    {
        public long Id { get; set; }
        public string  Username { get; set; }
        public int Reviews{ get; set; }
        
    }
}