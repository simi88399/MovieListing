using MovieList.Interfaces;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieList.Controllers
{
    
    public class MovieListController : Controller
    {
        private readonly IMovieListRepo _movieListRepo;
        public MovieListController(IMovieListRepo movieListRepo)
        {
            _movieListRepo = movieListRepo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = _movieListRepo.GetAll();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MovieListModel req)
        {
            try
            {
                
                var data = _movieListRepo.Add(req);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult GetBYId(int id)
        {
            var data = _movieListRepo.Get(id);
            return View(data);
        }
        [HttpGet]
        public ActionResult update(int id)
        {
            var data = _movieListRepo.Get(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult update(MovieListModel req)
        {
            try
            {

                var data = _movieListRepo.Update(req);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = _movieListRepo.Delete(id);
            return View(data);
        }
    }
}