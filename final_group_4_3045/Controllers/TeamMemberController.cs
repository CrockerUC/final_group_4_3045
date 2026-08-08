using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final_group_4_3045.Models;
using final_group_4_3045.Data;

namespace final_group_4_3045.Controllers;

public class TeamMemberController : Controller
{
    private readonly ILogger<TeamMemberController> _logger;

    private readonly AppDbContext _context;

    public TeamMemberController(ILogger<TeamMemberController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    /* --------- CRUD METHODS FOR TEAMMEMBER MODEL --------- */

    // Create the initial table ONLY USE ON INITIALIZATION
    public IActionResult CreateTeamMemberTable()
    {
        // Logic to create the TeamMember table in the database
        // Use entity framework to create the table based on the TeamMember model
        return View("Index");
    }

    [HttpGet]
    public IActionResult ReadTeamMembers(int? id)
    {
        // Logic to read TeamMember data from the database
        // Use entity framework to retrieve data from the TeamMember table
        if (id == null || id == 0)
        {
            return Ok(_context.TeamMembers.Take(5).ToList());
        }
        var member = _context.TeamMembers.Find(id);
        if (member == null)
        {
            return NotFound();
        }
        return Ok(member);
    }

    public IActionResult UpdateTeamMember()
    {
        // Logic to update TeamMember data in the database
        // Use entity framework to update data in the TeamMember table
        return View("Index");
    }

    public IActionResult DeleteTeamMember()
    {
        // Logic to delete TeamMember data from the database
        // Use entity framework to delete data from the TeamMember table
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}