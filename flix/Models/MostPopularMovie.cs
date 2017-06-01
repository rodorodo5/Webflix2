using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class MostPopularMovie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string  Path { get; set; }
        public char Rank { get; set; }

    }
}