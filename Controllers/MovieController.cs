using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {

            MovieDBHandler movieDB = new MovieDBHandler();
            ModelState.Clear();
            return View(movieDB.ListaPeliculas());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(MovieModel moviemodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     MovieDBHandler movieDB = new MovieDBHandler ();
                    if (movieDB.AgregaPelicula(moviemodel))
                    {
                        ViewBag.Message = "Pelicula agregada Satisfactoriamente";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        // POST: MovieController/Create
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
        // *** EDITAR ** ***
        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            MovieDBHandler movieDB = new MovieDBHandler();
            return View(movieDB.ListaPeliculas().Find(movieDB => movieDB.PeliculaID == id));
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieModel moviemodel)
        {
            try
            {
                MovieDBHandler movieDB = new MovieDBHandler();
                movieDB.ActualizaPelicula(moviemodel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
