using baconsale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace baconsale.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MyMovies(MovieResponse response)
        {
            /*If the validation shows there isn't anything wrong with the values, add the movies to the storage and reload the page*/
            if(ModelState.IsValid)
            {
                TempStorage.AddMovie(response);
                Response.Redirect("MyMovies");
            }
            return View();
        }

        public IActionResult MovieList()
        {
            /*Returns list of movies, except for any with the title "Independence Day"*/
            return View(TempStorage.Movies.Where(m => m.Title != "Independence Day"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
