using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTracker.Models;

// Hadley Garff 4-14
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

        // This is a get to show the movie form, it accesses the different categories in the database
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _moviecontext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View();
        }

        // This is the post, it picks the movie category from the movie bag, if the movie id is not 0 it will add a new movie
        [HttpPost]
        public IActionResult MovieForm(Movie movie)
        {
            ViewBag.Categories = _moviecontext.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            if (movie.MovieId != 0)
            {
                _moviecontext.Entry(movie).State = EntityState.Modified;
            }
            else 
            {
                _moviecontext.Movies.Add(movie);
            }

            _moviecontext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        // This shows the movie list, it includes the category and is in alphabetical order
        public IActionResult MovieList()
        {

            var movies = _moviecontext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();
            return View(movies);
        }

        // This is the get for edit, it creates a record to edit (with the id), and sends it to the Movie form page
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var recordtoedit = _moviecontext.Movies
                .Include(x => x.Category) 
                .SingleOrDefault(x => x.MovieId == id); 

            ViewBag.Categories = _moviecontext.Categories
                .OrderBy(c => c.CategoryName) 
                .ToList();


            return View("MovieForm", recordtoedit);
        }


        // This is a post once you have edited a movie, it updates the movie based on the id
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _moviecontext.Update(updatedMovie);
            _moviecontext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        // This is the get for deleting based upon the id
        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            var movie = _moviecontext.Movies
                .Include(x => x.Category)
                .FirstOrDefault(x => x.MovieId == id);
                
                if (movie == null)
            {
                return NotFound();
            }
            
            return View(movie);
        }

        // If they confirm the delte, it will remove the move and take the user back to movielist
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movie = _moviecontext.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            _moviecontext.Movies.Remove(movie); 
            _moviecontext.SaveChanges(true);

            return RedirectToAction("MovieList");
        }

    }
}
