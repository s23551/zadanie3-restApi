using System.ComponentModel.DataAnnotations;

namespace zadanie3_restApi.Animals;

public class AnimalDTO
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Category { get; set; }

    [Required]
    [MaxLength(200)]
    public string Area { get; set; }
}