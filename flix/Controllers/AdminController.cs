using flix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace flix.Controllers
{
    public class AdminController : Controller
    {
        [HandleError]
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }

        #region Movie
        public ActionResult AdminMovieGetAll()
        {
            MovieDBHelper movieHelper = new MovieDBHelper();
            ModelState.Clear();
            return View(movieHelper.GetAll());
        }

        public ActionResult AdminMovieGetOne(long id)
        {
            MovieDBHelper movieHelper = new MovieDBHelper();
            ModelState.Clear();
            return View(movieHelper.GetById(id));
        }

        public ActionResult AdminMovieCreate(Movie model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    MovieDBHelper movieHelper = new MovieDBHelper();
                    if(movieHelper.Add(model))
                    {
                        ViewBag.Message = "Movie added successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult AdminMovieEdit(int id)
        {
            MovieDBHelper movieHelper = new MovieDBHelper();
            return View(movieHelper.GetById(id));
        }

        public ActionResult AdminMovieEdit(int id, Movie model)
        {
            try
            {
                MovieDBHelper movieHelper = new MovieDBHelper();
                movieHelper.Update(model);
                return RedirectToAction("AdminMovieGet");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AdminMovieDelete(long id)
        {
            try
            {
                MovieDBHelper movieHelper = new MovieDBHelper();
                if (movieHelper.Delete(id))
                {
                    ViewBag.AlertMsg = "Movie deleted successfully";
                }
                return RedirectToAction("AdminMovieGet");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Actor
        public ActionResult AdminActorGetAll()
        {
            ActorDBHelper actorHelper = new ActorDBHelper();
            ModelState.Clear();
            return View(actorHelper.GetAll());
        }

        public ActionResult AdminActorGetOne(long id)
        {
            ActorDBHelper actorHelper = new ActorDBHelper();
            ModelState.Clear();
            return View(actorHelper.GetById(id));
        }

        public ActionResult AdminActorCreate(Actor model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ActorDBHelper actorHelper = new ActorDBHelper();
                    if (actorHelper.Add(model))
                    {
                        ViewBag.Message = "Actor added successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult AdminActorEdit(int id)
        {
            ActorDBHelper actorHelper = new ActorDBHelper();
            return View(actorHelper.GetById(id));
        }

        public ActionResult AdminActorEdit(int id, Actor model)
        {
            try
            {
                ActorDBHelper actorHelper = new ActorDBHelper();
                actorHelper.Update(model);
                return RedirectToAction("AdminActorGet");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AdminActorDelete(long id)
        {
            try
            {
                ActorDBHelper actorHelper = new ActorDBHelper();
                if (actorHelper.Delete(id))
                {
                    ViewBag.AlertMsg = "Actor deleted successfully";
                }
                return RedirectToAction("AdminActorGet");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Genre
        public ActionResult AdminGenreGetAll()
        {
            GenreDBHelper genreHelper = new GenreDBHelper();
            ModelState.Clear();
            return View(genreHelper.GetAll());
        }

        public ActionResult AdminGenreGetOne(long id)
        {
            GenreDBHelper genreHelper = new GenreDBHelper();
            ModelState.Clear();
            return View(genreHelper.GetById(id));
        }

        public ActionResult AdminGenreCreate(Genre model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GenreDBHelper genreHelper = new GenreDBHelper();
                    if (genreHelper.Add(model))
                    {
                        ViewBag.Message = "Genre added successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult AdminGenreEdit(int id)
        {
            GenreDBHelper genreHelper = new GenreDBHelper();
            return View(genreHelper.GetById(id));
        }

        public ActionResult AdminGenreEdit(int id, Genre model)
        {
            try
            {
                GenreDBHelper genreHelper = new GenreDBHelper();
                genreHelper.Update(model);
                return RedirectToAction("AdminGenreGet");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AdminGenreDelete(long id)
        {
            try
            {
                GenreDBHelper genreHelper = new GenreDBHelper();
                if (genreHelper.Delete(id))
                {
                    ViewBag.AlertMsg = "Genre deleted successfully";
                }
                return RedirectToAction("AdminGenreGet");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Director
        public ActionResult AdminDirectorGetAll()
        {
            DirectorDBHelper directorHelper = new DirectorDBHelper();
            ModelState.Clear();
            return View(directorHelper.GetAll());
        }

        public ActionResult AdminDirectorGetOne(long id)
        {
            DirectorDBHelper directorHelper = new DirectorDBHelper();
            ModelState.Clear();
            return View(directorHelper.GetById(id));
        }

        public ActionResult AdminDirectorCreate(Director model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DirectorDBHelper directorHelper = new DirectorDBHelper();
                    if (directorHelper.Add(model))
                    {
                        ViewBag.Message = "Director added successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult AdminDirectorEdit(int id)
        {
            DirectorDBHelper directorHelper = new DirectorDBHelper();
            return View(directorHelper.GetById(id));
        }

        public ActionResult AdminDirectorEdit(int id, Director model)
        {
            try
            {
                DirectorDBHelper directorHelper = new DirectorDBHelper();
                directorHelper.Update(model);
                return RedirectToAction("AdminDirectorGet");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AdminDirectorDelete(long id)
        {
            try
            {
                DirectorDBHelper directorHelper = new DirectorDBHelper();
                if (directorHelper.Delete(id))
                {
                    ViewBag.AlertMsg = "Director deleted successfully";
                }
                return RedirectToAction("AdminDirectorGet");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Poster
        public ActionResult AdminPosterGetAll()
        {
            PosterDBHelper posterHelper = new PosterDBHelper();
            ModelState.Clear();
            return View(posterHelper.GetAll());
        }

        public ActionResult AdminPosterGetOne(long id)
        {
            PosterDBHelper posterHelper = new PosterDBHelper();
            ModelState.Clear();
            return View(posterHelper.GetById(id));
        }

        public ActionResult AdminPosterCreate(Poster model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PosterDBHelper posterHelper = new PosterDBHelper();
                    if (posterHelper.Add(model))
                    {
                        ViewBag.Message = "Poster added successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult AdminPosterEdit(int id)
        {
            PosterDBHelper posterHelper = new PosterDBHelper();
            return View(posterHelper.GetById(id));
        }

        public ActionResult AdminPosterEdit(int id, Poster model)
        {
            try
            {
                PosterDBHelper posterHelper = new PosterDBHelper();
                posterHelper.Update(model);
                return RedirectToAction("AdminPosterGet");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AdminPosterDelete(long id)
        {
            try
            {
                PosterDBHelper posterHelper = new PosterDBHelper();
                if (posterHelper.Delete(id))
                {
                    ViewBag.AlertMsg = "Poster deleted successfully";
                }
                return RedirectToAction("AdminPosterGet");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region User
        public ActionResult AdminUserGetAll()
        {
            UserDBHelper userHelper = new UserDBHelper();
            ModelState.Clear();
            return View(userHelper.GetAll());
        }

        public ActionResult AdminUserGetOne(long id)
        {
            UserDBHelper userHelper = new UserDBHelper();
            ModelState.Clear();
            return View(userHelper.GetById(id));
        }

        public ActionResult AdminUserCreate(Models.User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDBHelper userHelper = new UserDBHelper();
                    if (userHelper.Add(model))
                    {
                        ViewBag.Message = "User added successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult AdminUserEdit(int id)
        {
            UserDBHelper userHelper = new UserDBHelper();
            return View(userHelper.GetById(id));
        }

        public ActionResult AdminUserEdit(int id, Models.User model)
        {
            try
            {
                UserDBHelper userHelper = new UserDBHelper();
                userHelper.Update(model);
                return RedirectToAction("AdminUserGet");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AdminUserDelete(long id)
        {
            try
            {
                UserDBHelper userHelper = new UserDBHelper();
                if (userHelper.Delete(id))
                {
                    ViewBag.AlertMsg = "User deleted successfully";
                }
                return RedirectToAction("AdminUserGet");
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}