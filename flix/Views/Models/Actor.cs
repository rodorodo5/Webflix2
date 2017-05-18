using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class Actor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string path_image { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}