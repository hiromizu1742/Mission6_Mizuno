using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_6.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_6.Controllers;

public class HomeController : Controller
{
    // Main EF Core context used for movie CRUD operations.
    private ApplicationContext _context;
    
    public HomeController(ApplicationContext context)
    {
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

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult ListMovies()
    {
        // Load movies with category names for the list page.
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Application()
    {
        // Reuse AddMovie view for creating a new movie.
        ViewBag.FormAction = "Application";
        ViewBag.SubmitText = "Submit Movie";
        return View("AddMovie", new Movies());
    }

    [HttpPost]
    public IActionResult Application(Movies response)
    {
        if (!ModelState.IsValid)
        {
            // Keep user input and show validation messages.
            ViewBag.FormAction = "Application";
            ViewBag.SubmitText = "Submit Movie";
            return View("AddMovie", response);
        }

        _context.Movies.Add(response);
        _context.SaveChanges();

        return RedirectToAction("ListMovies");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Load selected movie and reuse AddMovie view in edit mode.
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.FormAction = "Edit";
        ViewBag.SubmitText = "Update Movie";
        return View("AddMovie", movie);
    }

    [HttpPost]
    public IActionResult Edit(Movies response)
    {
        if (!ModelState.IsValid)
        {
            // Keep edit mode and show validation errors.
            ViewBag.FormAction = "Edit";
            ViewBag.SubmitText = "Update Movie";
            return View("AddMovie", response);
        }

        _context.Movies.Update(response);
        _context.SaveChanges();
        return RedirectToAction("ListMovies");
    }

    [HttpGet]
    public IActionResult DeleteConfirm(int id)
    {
        // Show confirmation before deleting a movie.
        var movie = _context.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View("DeleteConfirm", movie);
    }

    [HttpPost, ActionName("DeleteConfirm")]
    public IActionResult DeleteConfirmed(int movieId)
    {
        // Delete the selected movie after user confirms.
        var existingMovie = _context.Movies
            .FirstOrDefault(x => x.MovieId == movieId);

        if (existingMovie == null)
        {
            return NotFound();
        }
        
        _context.Movies.Remove(existingMovie);
        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "An error occurred while trying to delete the movie.");
            return View("DeleteConfirm", existingMovie);
        }

        return RedirectToAction("ListMovies");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
