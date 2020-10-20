using System;
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

        public void CreateHowToItem(HowToItem howToItem)
        {
            if(howToItem == null)
            {
                throw new ArgumentNullException(nameof(howToItem));
            }

            _context.Add(howToItem);
            SaveChanges();
        }

        public void Delete(HowToItem howToItem)
        {
            if(howToItem is null)
            {
                throw new ArgumentNullException(nameof(howToItem));
            }
            _context.Remove(howToItem);
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

        public void Update(HowToItem item)
        {
            //No action required. DBContext is tracking changes. Don't forget to save the changes though.
        }
    }
}