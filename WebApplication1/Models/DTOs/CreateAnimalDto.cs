using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class CreateAnimalDto
{
    [Required]
    [DefaultValue("Monkey")]
    [MaxLength(200)]
    public string Name { get; set; }

    [DefaultValue("")]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    [DefaultValue("Mammal")]
    [MaxLength(200)]
    public string Category { get; set; }
    
    [Required]
    [DefaultValue("Africa")]
    [MaxLength(200)]
    public string Area { get; set; }
    
}