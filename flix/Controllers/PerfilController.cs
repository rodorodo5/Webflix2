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
<<<<<<< HEAD
        [HandleError]
=======
       
>>>>>>> 0744d89e7c2f8535c869bd58f00ab58e131fafbf
        public ActionResult Perfil(long id)
        {
            var dataUser = new UserDBHelper();
            if (dataUser.UserExist(id) >= 1)
            {
                 var viewModel = new UserViewMovel()
                {
                    LUser = dataUser.GetById(id),
                    ProfileViewModel = dataUser.GetUserProfileById(id)
                };
                return View(viewModel);
            }
            return View();
        }
    }
}