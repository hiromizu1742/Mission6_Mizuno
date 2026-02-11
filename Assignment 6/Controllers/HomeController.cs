using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_6.Models;

namespace Assignment_6.Controllers;

public class HomeController : Controller
{
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
    public IActionResult Application()
    {
        return View("AddMovie");
    }

    [HttpPost]
    public IActionResult Application( Application response)
    {
        _context.Applications.Add(response);// Add record to the database
        _context.SaveChanges();
        
        return View("AddMovie", response);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}