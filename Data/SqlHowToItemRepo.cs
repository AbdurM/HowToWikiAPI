using System.Collections.Generic;
using System.Linq;
using HowToWikiAPI.Models;

namespace HowToWikiAPI.Data
{
    public class SqlHowToItemRepo : IHowToItemRepo
    {
        private HowToContext _context;

        public SqlHowToItemRepo(HowToContext context)
        {
            _context = context;
        }
        public IEnumerable<HowToItem> GetAllHowToItems()
        {
           return _context.HowToItems.ToList();
        }

        public HowToItem GetHowToItemById(int id)
        {
            return _context.HowToItems.FirstOrDefault(x=> x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}