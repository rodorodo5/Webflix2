using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class GetLastReviews
    {
        public long Id  { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
 
    }
}