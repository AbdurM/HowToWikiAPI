using System.ComponentModel.DataAnnotations;

namespace HowToWikiAPI.Dtos
{
    public class HowToCreateDto
    {
       [Required]
       [MaxLength(150)]  
       public string Title { get; set; }
       [Required]
       public string Instructions { get; set; }
       [Required]
       public string Category { get; set; }
    }
}