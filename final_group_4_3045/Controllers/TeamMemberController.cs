using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;
using final_group_4_3045.Data;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamMemberController : ControllerBase
{
    private readonly ILogger<TeamMemberController> _logger;
    private readonly ITeamMemberContextDAO _teamMemberDAO;

    public TeamMemberController(
        ILogger<TeamMemberController> logger,
        ITeamMemberContextDAO teamMemberDAO)
    {
        _logger = logger;
        _teamMemberDAO = teamMemberDAO;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeamMember>>> GetTeamMembers()
    {
        _logger.LogInformation("Getting all team members.");
        var teamMembers = await _teamMemberDAO.GetAllTeamMembersAsync();
        return Ok(teamMembers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
    {
        _logger.LogInformation("Getting team member with ID {Id}.", id);
        var teamMember = await _teamMemberDAO.GetTeamMemberByIdAsync(id);
        if (teamMember == null)
        {
            _logger.LogWarning("Team member with ID {Id} was not found.", id);
            return NotFound();
        }
        return Ok(teamMember);
    }

    [HttpPost]
    public async Task<ActionResult<TeamMember>> CreateTeamMember(TeamMember teamMember)
    {
        _logger.LogInformation("Creating a new team member.");
        await _teamMemberDAO.AddTeamMemberAsync(teamMember);
        return CreatedAtAction(
            nameof(GetTeamMember),
            new { id = teamMember.Id },
            teamMember);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeamMember(int id, TeamMember teamMember)
    {
        _logger.LogInformation("Updating team member with ID {Id}.", id);
        var existingTeamMember = await _teamMemberDAO.GetTeamMemberByIdAsync(id);
        if (existingTeamMember == null)
        {
            _logger.LogWarning("Team member with ID {Id} was not found.", id);
            return NotFound();
        }
        teamMember.Id = id;
        await _teamMemberDAO.UpdateTeamMemberAsync(teamMember);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeamMember(int id)
    {
        _logger.LogInformation("Deleting team member with ID {Id}.", id);
        var existingTeamMember = await _teamMemberDAO.GetTeamMemberByIdAsync(id);
        if (existingTeamMember == null)
        {
            _logger.LogWarning("Team member with ID {Id} was not found.", id);
            return NotFound();
        }
        if(string.IsNullOrEmpty(existingTeamMember.FullName))
        {
            _logger.LogWarning("Team member with ID {Id} has an empty FullName.", id);
            return StatusCode(500, "An error occurred while processing your request");

        }
        await _teamMemberDAO.DeleteTeamMemberAsync(id);
        return NoContent();
    }
}