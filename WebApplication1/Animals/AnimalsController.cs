using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Animals;

[ApiController]
[Route("/api/animals")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllAnimals([FromQuery] string orderBy)
    {
        var animals = _animalService.GetAllAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDto dto)
    {
        var success = _animalService.AddNewAnimal(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }
    
    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal([FromRoute]int idAnimal, Animal animal)
    {
        return NoContent();
    }
}