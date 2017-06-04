using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class MovieGenre
    {
        public long Id { get; set; }
        public long Genre_Id { get; set; }
        public long Movie_Id { get; set; }
        
    }
}