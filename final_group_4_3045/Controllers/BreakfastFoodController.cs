using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;
using final_group_4_3045.Data;
using System.Reflection.Metadata.Ecma335;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastFoodController : ControllerBase
{
    private readonly ILogger<BreakfastFoodController> _logger;
    private readonly IBreakfastContextDAO _breakfastDAO;

    public BreakfastFoodController(
        ILogger<BreakfastFoodController> logger,
        IBreakfastContextDAO breakfastFoodDAO)
    {
        _logger = logger;
        _breakfastDAO = breakfastFoodDAO;
    }

    /* --------- CRUD METHODS FOR BREAKFASTFOOD MODEL --------- */

    [HttpGet]
    public async Task<IActionResult> GetBreakfastFood(int? id)
    {
        // Logic to read BreakfastFood data from the database
        // Use entity framework to retrieve data from the BreakfastFood table
        _logger.LogInformation("Getting all breakfast foods.");

        var breakfastFoods = await _breakfastDAO.GetAllBreakfastFoodsAsync();
        return Ok(breakfastFoods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BreakfastFood>> GetBreakfastFood(int id)
    {
        _logger.LogInformation("Getting breakfast food with ID {Id}.", id);

        var breakfastFood = await _breakfastDAO.GetBreakfastFoodByIdAsync(id);

        if (breakfastFood == null)
        {
            _logger.LogWarning("Breakfast food with ID {Id} was not found.", id);
            return NotFound();
        }

        return Ok(breakfastFood);
    }

    // Create the initial table ONLY USE ON INITIALIZATION
    [HttpPost]
    public async Task<ActionResult<BreakfastFood>> CreateBreakfastFoodTable(BreakfastFood breakfastFood)
    {
        // Logic to create the BreakfastFood table in the database
        // Use entity framework to create the table based on the BreakfastFood model
        _logger.LogInformation("Creating a new breakfast food.");
        await _breakfastDAO.AddBreakfastFoodAsync(breakfastFood);
        return CreatedAtAction(
            nameof(GetBreakfastFood),
            new { id = breakfastFood.Id },
            breakfastFood);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBreakfastFood(int id, BreakfastFood breakfastFood)
    {
        // Logic to update BreakfastFood data in the database
        // Use entity framework to update data in the BreakfastFood table
        _logger.LogInformation("Updating breakfast food with ID {Id}.", id);

        var existingBreakfastFood = await _breakfastDAO.GetBreakfastFoodByIdAsync(id);

        if (existingBreakfastFood == null)
        {
            _logger.LogWarning("Breakfast food with ID {Id} was not found.", id);
            return NotFound();
        }

        breakfastFood.Id = id;

        await _breakfastDAO.UpdateBreakfastFoodAsync(breakfastFood);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBreakfastFood(int id)
    {
        // Logic to delete BreakfastFood data from the database
        // Use entity framework to delete data from the BreakfastFood table
        _logger.LogInformation("Deleting breakfast food with ID {Id}.", id);
        var breakfastFood = await _breakfastDAO.GetBreakfastFoodByIdAsync(id);
        if (breakfastFood == null)
        {
            _logger.LogWarning("Breakfast food with ID {Id} was not found.", id);
            return NotFound();
        }
        if (string.IsNullOrEmpty(breakfastFood.Name))
        {
            _logger.LogWarning("Breakfast food with ID {Id} has an empty name.", id);
            return StatusCode(500, "An error occurred while processing your request");
        }
        await _breakfastDAO.DeleteBreakfastFoodAsync(id);
        return NoContent();
    }
}