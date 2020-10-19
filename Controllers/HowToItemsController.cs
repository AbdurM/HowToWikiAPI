using System.Collections.Generic;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public HowToItemsController(IHowToItemRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/HowToItems
        [HttpGet]
        public ActionResult <IEnumerable<HowToReadDto>> GetAllHowToItems()
        {
            var howToItems = _repository.GetAllHowToItems();

            return Ok(_mapper.Map<IEnumerable<HowToReadDto>>(howToItems));
        }

        //GET api/HowToItem/{id}
        [HttpGet("{id}")]
        public ActionResult <HowToReadDto> GetHowToItemById(int id)
        {
            var howToItem = _repository.GetHowToItemById(id);

             if(howToItem is null)
                return NotFound();
                
            return Ok(_mapper.Map<HowToReadDto>(howToItem));
        } 

    }
}