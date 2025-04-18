using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers;

public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET: MovieController

        public IActionResult Details(int id)
        {
            var movies = _movieService.GetMovieDetails(id);
            return View(movies);
        }
        
        [HttpPost] 
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieService.DeleteMovie(id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                _movieService.DeleteMovie(id);
            }

            return RedirectToAction("Index", "Home");
            
            // or : return View("Index");
        }
    }