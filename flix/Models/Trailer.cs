using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class Trailer
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public Movie Movie { get; set; }
    }
}