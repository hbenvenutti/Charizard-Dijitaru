using AutoMapper;
using DijitaruVatigoSha.Context;
using DijitaruVatigoSha.Dtos;
using DijitaruVatigoSha.Dtos.Collaborator;
using DijitaruVatigoSha.Models;
using Microsoft.AspNetCore.Mvc;

namespace DijitaruVatigoSha.Controllers;

[ApiController]
[Route("collaborators")]
public class CollaboratorsController : ControllerBase
{
    private readonly DijitaruVatigoShaContext _context;
    private readonly IMapper _mapper;

    public CollaboratorsController(DijitaruVatigoShaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // *** --- routes --------------------------------------------------- *** //

    [HttpGet]
    public IEnumerable<ReadCollaboratorDto> ListCollaborators()
    {
        var collaborators = _context.Collaborators.ToList();

        return _mapper.Map<List<ReadCollaboratorDto>>(collaborators);
    }

    [HttpPost]
    public IActionResult CreateCollaborator(CreateCollaboratorDto dto)
    {
        var collaborator = _mapper.Map<Collaborator>(dto);

        _context.Collaborators.Add(collaborator);
        _context.SaveChanges();

        var responseDto = _mapper.Map<ReadCollaboratorDto>(collaborator);

        return CreatedAtAction(
            nameof(GetCollaboratorById), 
            new { collaborator.Id }, 
            responseDto
        );
    }

    [HttpGet("{id}")]
    public IActionResult GetCollaboratorById(int id)
    {
        var collaborator = _context.Collaborators
            .FirstOrDefault(collaborator => collaborator.Id == id);

        if (collaborator is null) return NotFound();

        var dto = _mapper.Map<ReadCollaboratorDto>(collaborator);

        return Ok(dto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCollaborator(int id)
    {
        var collaborator = _context.Collaborators
            .FirstOrDefault(collaborator => collaborator.Id == id);

        if (collaborator is null) return NotFound();

        _context.Collaborators.Remove(collaborator);
        _context.SaveChanges();

        return NoContent();
    }
}
