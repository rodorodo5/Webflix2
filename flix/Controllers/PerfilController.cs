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
        [HandleError]
        public ActionResult Perfil(long id)
        {
            var dataUser = new UserDBHelper();

            var viewModel = new UserViewMovel()
            {
                LUser = dataUser.GetById(id),
                ProfileViewModel = dataUser.GetUserProfileById(id)
            };

            return View(viewModel);
        }
    }
}