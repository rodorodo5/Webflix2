using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Genre> LGenres { get; set; }
        public Genre Genre { get; set; }
    }
}