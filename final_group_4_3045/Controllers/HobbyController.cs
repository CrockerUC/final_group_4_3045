using final_group_4_3045.Interfaces;
using final_group_4_3045.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace final_group_4_3045.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HobbyController : ControllerBase
{
    private readonly ILogger<HobbyController> _logger;
    private readonly IHobbyContextDAO _hobbyDAO;

    public HobbyController(
        ILogger<HobbyController> logger,
        IHobbyContextDAO hobbyDAO)
    {
        _logger = logger;
        _hobbyDAO = hobbyDAO;
    }

    [HttpGet]
    public async Task<ActionResult<List<Hobby>>> GetHobbies()
    {
        _logger.LogInformation("Getting all hobbies.");

        var hobbies = await _hobbyDAO.GetAllHobbiesAsync();

        return Ok(hobbies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Hobby>> GetHobby(int id)
    {
        _logger.LogInformation("Getting hobby with ID {Id}.", id);

        var hobby = await _hobbyDAO.GetHobbyByIdAsync(id);

        if (hobby == null)
        {
            _logger.LogWarning("Hobby with ID {Id} was not found.", id);
            return NotFound();
        }

        return Ok(hobby);
    }

    [HttpPost]
    public async Task<ActionResult<Hobby>> CreateHobby(Hobby hobby)
    {
        _logger.LogInformation("Creating a new hobby.");

        await _hobbyDAO.AddHobbyAsync(hobby);

        return CreatedAtAction(
            nameof(GetHobby),
            new { id = hobby.Id },
            hobby);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHobby(
        int id,
        Hobby hobby)
    {
        _logger.LogInformation(
            "Updating hobby with ID {Id}.", id);

        var existingHobby =
            await _hobbyDAO.GetHobbyByIdAsync(id);

        if (existingHobby == null)
        {
            _logger.LogWarning("Hobby with ID {Id} was not found for update.", id);
            return NotFound();
        }

        hobby.Id = id;

        await _hobbyDAO.UpdateHobbyAsync(hobby);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHobby(int id)
    {
        _logger.LogInformation(
            "Deleting hobby with ID {Id}.", id);

        var hobby = await _hobbyDAO.GetHobbyByIdAsync(id);

        if (hobby == null)
        {
            _logger.LogWarning("Hobby with ID {Id} was not found for deletion.", id);
            return NotFound();
        }
        if (string.IsNullOrEmpty(hobby.HobbyName))
        {
            _logger.LogWarning("Hobby with ID {Id} has an empty HobbyName.", id);
            return StatusCode(500, "An error occurred while processing your request");
        }

        await _hobbyDAO.DeleteHobbyAsync(id);

        return NoContent();
    }
}