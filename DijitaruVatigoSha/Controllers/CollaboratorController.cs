using Microsoft.AspNetCore.Mvc;

namespace DijitaruVatigoSha.Controllers;

[Route("[controller]")]
public class CollaboratorController : Controller
{
    private readonly ILogger<CollaboratorController> _logger;

    public CollaboratorController(ILogger<CollaboratorController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
