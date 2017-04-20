using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.Web.Models
{
    public class Genre
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}