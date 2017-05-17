using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class Poster
    {
        public long Id { get; set; }
        public string PathImage { get; set; }
        public Movie Movie { get; set; }
    }
}