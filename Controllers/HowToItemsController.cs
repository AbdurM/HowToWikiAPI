using System.Collections.Generic;
using AutoMapper;
using HowToWikiAPI.Data;
using HowToWikiAPI.Dtos;
using HowToWikiAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name = "GetHowToItemById")]
        public ActionResult <HowToReadDto> GetHowToItemById(int id)
        {
            var howToItem = _repository.GetHowToItemById(id);

             if(howToItem is null)
                return NotFound();
                
            return Ok(_mapper.Map<HowToReadDto>(howToItem));
        } 

        //POST api/HowToItems
        [HttpPost]
        public ActionResult <HowToReadDto> CreateHowToItem(HowToCreateDto howToCreateDto)
        {
            var howToItem = _mapper.Map<HowToItem>(howToCreateDto);

            _repository.CreateHowToItem(howToItem);

            _repository.SaveChanges();

            var howToReadDto = _mapper.Map<HowToReadDto>(howToItem);

            return CreatedAtRoute(nameof(GetHowToItemById), new {Id = howToReadDto.Id}, howToReadDto);
        } 

        //PUT api/HowToItem/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateHowToItem(int id, HowToUpdateDto howToUpdateDto)
        {
            var howToItemFromRepo = _repository.GetHowToItemById(id);

            if(howToItemFromRepo is null)
             return NotFound();

            _mapper.Map(howToUpdateDto, howToItemFromRepo);

            _repository.Update(howToItemFromRepo);
            _repository.SaveChanges();

            return NoContent(); //returning 204
        }

        //Patch api/HowToItems/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<HowToUpdateDto> patchDoc)
        {
             var howToItemFromRepo = _repository.GetHowToItemById(id);

            if(howToItemFromRepo is null)
             return NotFound();

            HowToUpdateDto howToItemToPatch = _mapper.Map<HowToUpdateDto>(howToItemFromRepo); 
            patchDoc.ApplyTo(howToItemToPatch, ModelState);

            if(!TryValidateModel(howToItemToPatch))
            {
                return ValidationProblem(ModelState);
            }

             _mapper.Map(howToItemToPatch, howToItemFromRepo);

             _repository.Update(howToItemFromRepo);
             _repository.SaveChanges();

            return NoContent();
        }

    }
}