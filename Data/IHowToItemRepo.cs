using System.Collections.Generic;
using HowToWikiAPI.Models;

namespace HowToWikiAPI.Data
{
    public interface IHowToItemRepo
    {
        bool SaveChanges();
        IEnumerable<HowToItem> GetAllHowToItems();
        HowToItem GetHowToItemById(int id);
        void CreateHowToItem(HowToItem howToItem);
        void Update(HowToItem item);
        void Delete(HowToItem item);
        
    }
}