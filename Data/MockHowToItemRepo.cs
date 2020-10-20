using System.Collections.Generic;
using HowToWikiAPI.Models;

namespace HowToWikiAPI.Data
{
    public class MockHowToItemRepo : IHowToItemRepo
    {
        public void CreateHowToItem(HowToItem howToItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(HowToItem item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<HowToItem> GetAllHowToItems()
        {
            var howToItems = new List<HowToItem>
            {
                new HowToItem{
                    Id= 0,
                    Title = "How to make a cup of coffee?",
                    Instructions = "Boil water in a kettle and pour it into a cup. Add coffee as per taste and stir it with a spoon.",
                    Category = "Cooking"
                },
                new HowToItem{
                    Id= 0,
                    Title = "How to fry an egg?",
                    Instructions = "Heat a pan, add oil, crack an egg and let it cook until solid. Add salt and seasoning as per taste.",
                    Category = "Cooking"
                },
                new HowToItem{
                    Id= 0,
                    Title = "How to fix a car?",
                    Instructions = "Go to a Mechanic :-D",
                    Category = "Automobiles"
                }
            };

            return howToItems;
        }

        public HowToItem GetHowToItemById(int id)
        {
            return new HowToItem{
                        Id= 0,
                        Title = "How to fry an egg?",
                        Instructions = "Heat a pan, add oil, crack an egg and let it cook until solid. Add salt and seasoning as per taste.",
                        Category = "Cooking" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(HowToItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}