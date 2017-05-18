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
    }
}