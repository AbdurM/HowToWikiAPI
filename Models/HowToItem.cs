using System.ComponentModel.DataAnnotations;

namespace HowToWikiAPI.Models
{
    public class HowToItem
    {
       public int Id { get; set; }
       [Required]
       [MaxLength(150)]    
       public string Title { get; set; }
       [Required]
       public string Instructions { get; set; }
       [Required]
       public string Category { get; set; }
    }
}