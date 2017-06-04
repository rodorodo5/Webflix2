using flix.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class ReviewController : Controller
    {

    
        public ActionResult Review(int id)
        {
            var movieData = new MovieDBHelper();
            var viewModel = movieData.GetById(id);
            
           
            return View(viewModel);

        }

    }
}