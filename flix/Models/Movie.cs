using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.Web.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public string Length { get; set; }
        public string Sinopsis { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}