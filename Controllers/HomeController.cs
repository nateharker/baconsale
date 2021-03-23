using baconsale.Models;
using baconsale.Models.ViewModel;
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
        //Variable to hold the DBContext instance while app is running
        private MovieListContext _context { get; set; }
        //Variable to hold the MovieResponseId for update operations
        private static int _movieId = -1;

        public HomeController(ILogger<HomeController> logger, MovieListContext context)
        {
            _logger = logger;
            _context = context;
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
            /*If the validation shows there isn't anything wrong with the values, add the movies to the db and reload the page*/
            if(ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                Response.Redirect("MyMovies");
            }
            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            /*Returns IEnumerable of movies, except for any with the title "Independence Day"*/
            return View(new MovieListViewModel 
            {
                Movies = _context.Movies
                    .Where(x => x.Title != "Independence Day")
            });
        }

        [HttpPost]
        public IActionResult MovieList(int movieId)
        {
            //Happens on delete button post, finds the movie that matches the ID number and removes it from DB, then reloads the MovieList
            MovieResponse response = _context.Movies.FirstOrDefault(x => x.MovieResponseId == movieId);
            _context.Movies.Remove(response);
            _context.SaveChanges();
            return View(new MovieListViewModel
            {
                Movies = _context.Movies
                    .Where(x => x.Title != "Independence Day")
            });
        }

        [HttpPost]
        public IActionResult UpdateConfirmation(MovieResponse response)
        {
            //Happens on post for updated response, finds the movie that matches the ID and changes each value to the values entered in the form, then loads the movie list
            if (ModelState.IsValid)
            {
                MovieResponse movieResponse = _context.Movies.FirstOrDefault(x => x.MovieResponseId == _movieId);
                movieResponse.Category = response.Category;
                movieResponse.Title = response.Title;
                movieResponse.Year = response.Year;
                movieResponse.Director = response.Director;
                movieResponse.Rating = response.Rating;
                movieResponse.Edited = response.Edited;
                movieResponse.LentTo = response.LentTo;
                movieResponse.Notes = response.Notes;
                _context.SaveChanges();
                return View("MovieList", new MovieListViewModel
                {
                    Movies = _context.Movies
                    .Where(x => x.Title != "Independence Day")
                });
            }
            else
            {
                return View("Update", response);
            }
        }

        [HttpPost]
        public IActionResult Update(int movieId)
        {
            //Happens on update button post, finds the movie that matches the ID from the movie list and sends that object to the update page to populate the input fields there
            _movieId = movieId;
            MovieResponse response = _context.Movies.FirstOrDefault(x => x.MovieResponseId == _movieId);
            return View(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
