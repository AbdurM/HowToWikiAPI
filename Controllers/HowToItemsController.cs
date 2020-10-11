using System.Collections.Generic;
using HowToWikiAPI.Data;
using HowToWikiAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HowToWikiAPI.Controllers
{
    [Route("api/HowToItems")]
    [ApiController]
    public class HowToItemsController: ControllerBase
    {
        private readonly IHowToItemRepo _repository;
        public HowToItemsController(IHowToItemRepo repository)
        {
            _repository = repository;
        }

        //GET api/HowToItems
        [HttpGet]
        public ActionResult <IEnumerable<HowToItem>> GetAllHowToItems()
        {
            var howToItems = _repository.GetAllHowToItems();

            return Ok(howToItems);
        }

        //GET api/HowToItem/{id}
        [HttpGet("{id}")]
        public ActionResult <HowToItem> GetHowToItemById(int id)
        {
            var howToItem = _repository.GetHowToItemById(id);

            if(howToItem is null)
                return NotFound();

            return howToItem;
        } 

    }
}