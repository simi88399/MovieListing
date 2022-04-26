using MovieList.Interfaces;
using MovieList.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieList.Controllers
{
    
    public class MovieListController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();
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
        [Obsolete]
        public ActionResult Create(MovieListModel req)
        {
            try
            {
                
                var data = _movieListRepo.Add(req);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                logger.ErrorException("Error occured in Movie controller create Action",ex);
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
        [HttpGet]
        [Obsolete]
        public ActionResult Delete(int Id)
        {
            try
            {
                var data = _movieListRepo.Delete(Id);
                return Json(true);
            }
            catch (Exception ex)
            {
                logger.ErrorException("Error occured in Movie controller index Action", ex);
                return Json(false);
            }
        }
    }
}