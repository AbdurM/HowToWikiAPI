using System.ComponentModel.DataAnnotations;

namespace HowToWikiAPI.Dtos
{
    public class HowToReadDto
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public string Instructions { get; set; }
    }
}