using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;

namespace final_group_4_3045.Controllers;

public class HobbyController : Controller
{
    private readonly ILogger<HobbyController> _logger;

    public HobbyController(ILogger<HobbyController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    /* --------- CRUD METHODS FOR HOBBY MODEL --------- */

    // Create the initial table ONLY USE ON INITIALIZATION
    public IActionResult CreateHobbyTable()
    {
        // Logic to create the Hobby table in the database
        // Use entity framework to create the table based on the Hobby model
        return View("Index");
    }

    public IActionResult ReadHobby(int? id)
    {
        // Logic to read Hobby data from the database
        // Use entity framework to retrieve data from the Hobby table
        return View("Index");
    }

    public IActionResult UpdateHobby()
    {
        // Logic to update Hobby data in the database
        // Use entity framework to update data in the Hobby table
        return View("Index");
    }

    public IActionResult DeleteHobby()
    {
        // Logic to delete Hobby data from the database
        // Use entity framework to delete data from the Hobby table
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}