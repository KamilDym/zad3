using Microsoft.AspNetCore.Mvc;
using WebApplication1.Animals;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

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
    public IActionResult UpdateAnimal([FromRoute]int idAnimal, CreateAnimalDto animal)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest($"Incomplete data");
        }

        if (_animalService.Exist(idAnimal))
        {
            _animalService.UpdateAnimal(idAnimal,animal);
            
        }
        else
        {
            return NotFound();
        }
        
        return Ok(animal);
    }

    [HttpDelete("{idAnimal}")]
    public IActionResult DeleteAnimal([FromRoute] int idAnimal)
    {
        var success = _animalService.DeleteAnimal(idAnimal);
        return success ? StatusCode(StatusCodes.Status200OK) : Conflict();
    }
}