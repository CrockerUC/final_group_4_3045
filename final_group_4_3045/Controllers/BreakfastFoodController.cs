using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;
using final_group_4_3045.Data;
using System.Reflection.Metadata.Ecma335;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastFoodController : Controller
{
    private readonly ILogger<BreakfastFoodController> _logger;
    private readonly IBreakfastContextDAO _breakfastDAO;

    public BreakfastFoodController(ILogger<BreakfastFoodController> logger, IBreakfastContextDAO breakfastFoodDAO)
    {
        _logger = logger;
        _breakfastDAO = breakfastFoodDAO;
    }

    public IActionResult Index()
    {
        return View();
    }

    /* --------- CRUD METHODS FOR BREAKFASTFOOD MODEL --------- */

    // Create the initial table ONLY USE ON INITIALIZATION
    [HttpPost]
    public async Task<ActionResult<BreakfastFood>> CreateBreakfastFoodTable(BreakfastFood breakfastFood)
    {
        // Logic to create the BreakfastFood table in the database
        // Use entity framework to create the table based on the BreakfastFood model
        await _breakfastDAO.AddBreakfastFoodAsync(breakfastFood);
        return Ok(breakfastFood);
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