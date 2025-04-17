using System.Diagnostics;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers;

public class HomeController : Controller
{
    private MovieService _movieService;

    public HomeController(MovieService movieService)
    {
        _movieService = new MovieService();
    }
    public IActionResult Index()
    {
        var movies = _movieService.Top20GrossingMovies();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}