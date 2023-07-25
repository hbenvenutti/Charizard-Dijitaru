using AutoMapper;
using DijitaruVatigoSha.Context;
using DijitaruVatigoSha.Dtos.Hour;
using DijitaruVatigoSha.Enums;
using DijitaruVatigoSha.Models;
using Microsoft.AspNetCore.Mvc;

// -------------------------------------------------------------------------- //

namespace DijitaruVatigoSha.Controllers;

[ApiController]
[Route("hours")]
public class HoursController : ControllerBase
{
    private readonly DijitaruVatigoShaContext _context;
    private readonly IMapper _mapper;

    public HoursController(DijitaruVatigoShaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // *** --- routes --------------------------------------------------- *** //
    
    [HttpGet("registers")]
    public IEnumerable<ReadHoursDto> ListHours()
    {
        var hours = _context.Hours.ToList();

        return _mapper.Map<List<ReadHoursDto>>(hours);
    }

    // ---------------------------------------------------------------------- //

    [HttpGet("registers/{id}")]
    public IActionResult GetHourById(int id)
    {
        var hour = _context.Hours
            .FirstOrDefault(hour => hour.Id == id);

        if (hour is null) return NotFound();

        var dto = _mapper.Map<ReadHoursDto>(hour);

        return Ok(dto);
    }

    // ---------------------------------------------------------------------- //

    [HttpPost("registers")]
    public IActionResult CreateHour(CreateHoursDto dto)
    {
        var hour = _mapper.Map<PendingHour>(dto);

        _context.Hours.Add(hour);
        _context.SaveChanges();

        var responseDto = _mapper.Map<ReadHoursDto>(hour);

        return CreatedAtAction(
            nameof(GetHourById), 
            new { hour.Id }, 
            responseDto
        );
    }

    // ---------------------------------------------------------------------- //

    [HttpDelete("registers/{id}")]
    public IActionResult DeleteHour(int id)
    {
        var hour = _context.Hours
            .FirstOrDefault(hour => hour.Id == id);

        if (hour is null) return NotFound();

        _context.Hours.Remove(hour);
        _context.SaveChanges();

        return NoContent();
    }

    // ---------------------------------------------------------------------- //

    [HttpPost("registers/{id}/approve")]
    public IActionResult ApproveHour(int id, [FromBody] ApproveHourDto dto)
    {
        // *** --- check hours ------------------------------------------ *** //

        var hour = _context.Hours
            .FirstOrDefault(hour => hour.Id == id);

        if (hour is null) return NotFound();

        // *** --- check approver --------------------------------------- *** //

        var collaborator = _context.Collaborators
            .FirstOrDefault(collaborator => collaborator.Id == dto.ApproverId);

        if (collaborator is null) return NotFound();

        if (collaborator.Role == Role.Normal) return Unauthorized();

        // *** --- check project ---------------------------------------- *** //

        var project = _context.Projects
            .FirstOrDefault(project => project.Id == hour.ProjectId);

        if (project is null) return NotFound();

        if (collaborator.Role == Role.Approver)
        {
            var projectApprover = project.Approvers
                .FirstOrDefault(approver => approver.Id == collaborator.Id);
            
            if (projectApprover is null) return Unauthorized();
        }

        // *** --- success ---------------------------------------------- *** //

        hour.IsApproved = true;
        hour.Approver = collaborator;

        _context.SaveChanges();

        return NoContent();
    }

    // *** --- Approved Hours ------------------------------------------- *** //

    [HttpGet("approved")]
    public IEnumerable<ReadHoursDto> ListApprovedHours()
    {
        var hours = _context.Hours
            .Where(hour => hour.IsApproved)
            .ToList();

        return _mapper.Map<List<ReadHoursDto>>(hours);
    }

    // ---------------------------------------------------------------------- //

    [HttpGet("approved/{id}")]
    public IActionResult GetApprovedHourById(int id)
    {
        var hour = _context.Hours
            .FirstOrDefault(hour => hour.Id == id && hour.IsApproved);

        if (hour is null) return NotFound();

        var dto = _mapper.Map<ReadHoursDto>(hour);

        return Ok(dto);
    }
}
