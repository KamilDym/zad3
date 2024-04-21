using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Animals;

public class CreateAnimalDto
{
    [Required]
    [DefaultValue("Monkey")]
    public string Name { get; set; }
    [DefaultValue("")]
    public string Description { get; set; }
    [Required]
    [DefaultValue("Mamaml")]
    public string Category { get; set; }
    [Required]
    [DefaultValue("Africa")]
    public string Area { get; set; }
    
}