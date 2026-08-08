using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;
using final_group_4_3045.Data;

namespace final_group_4_3045.Controllers;

public class MovieController : Controller
{
    private readonly ILogger<MovieController> _logger;
    private readonly MovieDAO _movieDAO;

    public MovieController(ILogger<MovieController> logger, MovieDAO movieDAO)
    {
        _logger = logger;
        _movieDAO = movieDAO;
    }

    public IActionResult Index()
    {
        return View();
    }

    /* --------- CRUD METHODS FOR MOVIE MODEL --------- */

    // Create the initial table ONLY USE ON INITIALIZATION
    public IActionResult CreateMovieTable()
    {
        // Logic to create the Movie table in the database
        // Use entity framework to create the table based on the Movie model
        return View("Index");
    }

    public IActionResult ReadMovie(int? id)
    {
        // Logic to read Movie data from the database
        // Use entity framework to retrieve data from the Movie table
        return View("Index");
    }

    public IActionResult UpdateMovie()
    {
        // Logic to update Movie data in the database
        // Use entity framework to update data in the Movie table
        return View("Index");
    }

    public IActionResult DeleteMovie()
    {
        // Logic to delete Movie data from the database
        // Use entity framework to delete data from the Movie table
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}