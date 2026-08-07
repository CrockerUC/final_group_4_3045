using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;

namespace final_group_4_3045.Controllers;

public class BreakfastFoodController : Controller
{
    private readonly ILogger<BreakfastFoodController> _logger;

    public BreakfastFoodController(ILogger<BreakfastFoodController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    /* --------- CRUD METHODS FOR BREAKFASTFOOD MODEL --------- */

    // Create the initial table ONLY USE ON INITIALIZATION
    public IActionResult CreateBreakfastFoodTable()
    {
        // Logic to create the BreakfastFood table in the database
        // Use entity framework to create the table based on the BreakfastFood model
        return View("Index");
    }

    public IActionResult ReadBreakfastFood(int? id)
    {
        // Logic to read BreakfastFood data from the database
        // Use entity framework to retrieve data from the BreakfastFood table
        return View("Index");
    }

    public IActionResult UpdateBreakfastFood()
    {
        // Logic to update BreakfastFood data in the database
        // Use entity framework to update data in the BreakfastFood table
        return View("Index");
    }

    public IActionResult DeleteBreakfastFood()
    {
        // Logic to delete BreakfastFood data from the database
        // Use entity framework to delete data from the BreakfastFood table
        return View("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}