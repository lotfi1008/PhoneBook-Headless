using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Domain.Tags;
using PhoneBook.Core.Domain.Tags.Contracts;
using PhoneBook.Utilities;
using PhoneBook.Utilities.Apis;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : BaseController
    {
        private readonly TagRepository tagRepository;

        public TagController(TagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Tag>> Get()
        {
            var list = tagRepository.TableAsNoTracking.ToList();
            if (list==null || list.Count==0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetTag")]
        public IActionResult Get(int id)
        {
            var tag= tagRepository.GetById(id);
            if (tag==null)
            {
                return NotFound();
            }
            return  Ok(tag);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Tag tag)
        {
            var tagResult =tagRepository.Add(tag);
            return Created("api/Tag/"+tagResult.Id, tagResult);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tag tag)
        {
            if (id!=tag.Id)
            {
                return BadRequest();
            }
            var tagResult = tagRepository.Update(tag);
            return Accepted(tagResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tag = tagRepository.GetById(id);
            if (tag==null)
            {
                return NotFound();
            }
            var tagResult = tagRepository.Update(tag);
            return Ok();
        }



    }
}
