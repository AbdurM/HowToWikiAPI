using System.ComponentModel.DataAnnotations;

namespace HowToWikiAPI.Dtos
{
    public class HowToCreateDto
    {
       public string Title { get; set; }
       public string Instructions { get; set; }
       public string Category { get; set; }
    }
}