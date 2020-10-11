using HowToWikiAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HowToWikiAPI.Data
{
    public class HowToContext: DbContext
    {
        public DbSet<HowToItem> HowToItems { get; set; }
        public HowToContext(DbContextOptions<HowToContext> opt): base(opt)
        {
            
        }
    }
}