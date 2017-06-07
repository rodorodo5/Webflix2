using flix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class UserLController : Controller
    {
        // GET: UserL
        UserBL UserBL = new UserBL();
       
        public ActionResult UserL()
        {

            return View();
        }

        [HttpPost]
   
        public ActionResult UserL(UserL UserL)
        {
            


            string message = "";
            if (ModelState.IsValid)
            {

              
                if (UserBL.CheckUserLogin(UserL)>0)
                {
                    message = "Success";


        
                }
                else
                {
                    message = "Usuario o contrasena incorrecto";
                }
            }
            else
            {
                message = "Todos los campos son requeridos";
            }
            if (Request.IsAjaxRequest())
            {
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //!!!!!!!!!!!!!  Tiene que ser con algo como esto pero me truena.
       //int id = UserBL.CheckUserLogin(UserL);
       //             var userData = new UserDBHelper();
       //             var usr = userData.GetById(id);


       //             if (usr != null)
       //             {
       //                 foreach (var item in usr)
       //                 {
       //                     Session["UserID"] = item.Id;
       //                     Session["username"] = item.Username;
       //                     Session["FirstName"] = item.Name;


       //                 }

       //             }




    }
}