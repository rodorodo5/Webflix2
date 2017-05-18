using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flix.Models;

namespace flix.Controllers
{
    public class IndexController : Controller
    {
       
        
        public ActionResult Index()
        {
          
            var viewModel = new IndexViewModel()
            {
                Genre= new Genre(),
                LGenres = ConnectionDb.GetGenres()


            };

            return View();
        }
    }
}