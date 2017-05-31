using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flix.Models
{
    public class ReviewList
    {
        public long Id { get; set; }
        public long User_Id { get; set; }
        public string name { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }



    }
}