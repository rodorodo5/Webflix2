using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using flix.Models;

namespace flix.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Perfil(long id)
        {
            var data = new UserDBHelper();
            var viewModel = new UserViewMovel()
            {
                LUser = data.GetById(id)
            };
            
            
            return View(viewModel);
        }
    }
}