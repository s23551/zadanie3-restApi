using Microsoft.AspNetCore.Mvc;

namespace zadanie3_restApi.Animals;

[Route("/api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAnimals([FromQuery] string? orderBy)
    {
        if (orderBy != null || orderBy != "")
        {
            return Ok(_animalsService.GetAnimals(orderBy));
        }
        else
        {
            return Ok(_animalsService.GetAnimals("default"));
        }
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] AnimalDTO dto)
    {
        var success = _animalsService.AddAnimal(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }

    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal([FromBody] AnimalDTO dto, [FromRoute] int idAnimal)
    {
        var success = _animalsService.UpdateAnimal(idAnimal, dto);
        var animal = _animalsService.GetAnimal(idAnimal);
        return success ? Ok(animal) : Conflict();
    }

    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal([FromRoute] int idAnimal)
    {
        var success = _animalsService.DeleteAnimal(idAnimal);
        return success ? Ok() : Conflict("Not found");
    }
    
}