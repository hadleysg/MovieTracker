using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models;

namespace MovieTracker.Controllers
{
    public class HomeController : Controller

    {
        private MovieFormContext _moviecontext;

        public HomeController(MovieFormContext temp)
        {
            _moviecontext = temp;
        }

        // This is the view to the Index which is the main view.
        public IActionResult Index()
        {
            return View();
        }

        // This is the view to show all about Joel.
        public IActionResult Joel()
        {
            return View();
        }


        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _moviecontext.Movies.Add(movie);
                _moviecontext.SaveChanges();

                // Store a success message
                TempData["SuccessMessage"] = "Movie is submitted!";

                // Add code to save the movie to the database
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}
