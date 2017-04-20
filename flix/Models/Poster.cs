using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.Web.Models
{
    public class Poster
    {
        public long Id { get; set; }
        public string path_image { get; set; }
        public Movie Movie { get; set; }
    }
}