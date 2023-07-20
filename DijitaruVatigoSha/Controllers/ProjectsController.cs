using AutoMapper;
using DijitaruVatigoSha.Context;
using DijitaruVatigoSha.Dtos;
using DijitaruVatigoSha.Dtos.Project;
using DijitaruVatigoSha.Models;
using Microsoft.AspNetCore.Mvc;

namespace DijitaruVatigoSha.Controllers;

[ApiController]
[Route("projects")]
public class ProjectsController : ControllerBase
{
    private readonly DijitaruVatigoShaContext _context;
    private readonly IMapper _mapper;

    public ProjectsController(DijitaruVatigoShaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // *** --- routes --------------------------------------------------- *** //

    [HttpGet]
    public IEnumerable<ReadProjectDto> ListProjects()
    {
        var projects = _context.Projects.ToList();

        return _mapper.Map<List<ReadProjectDto>>(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetProjectById(int id)
    {
        var project = _context.Projects
            .FirstOrDefault(project => project.Id == id);

        if (project is null) return NotFound();

        var dto = _mapper.Map<ReadProjectDto>(project);

        return Ok(_mapper.Map<ReadProjectDto>(dto));
    }

    [HttpPost]
    public IActionResult CreateProject(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);

        _context.Projects.Add(project);
        _context.SaveChanges();

        var responseDto = _mapper.Map<ReadProjectDto>(project);

        return CreatedAtAction(nameof(GetProjectById), new { project.Id }, responseDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        var project = _context.Projects
            .FirstOrDefault(project => project.Id == id);

        if (project is null) return NotFound();

        _context.Projects.Remove(project);
        _context.SaveChanges();

        return NoContent();
    }
}

