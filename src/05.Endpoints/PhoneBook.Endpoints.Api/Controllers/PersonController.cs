using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Domain.People;
using PhoneBook.Core.Domain.People.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly PersonRepository personRepository;

        public PersonController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var list = personRepository.TableAsNoTracking.ToList();
            if (list == null || list.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult Get(int id)
        {
            var person = personRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            var personResult = personRepository.Add(person);
            return Created("api/Person/" + personResult.Id, personResult);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            var personResult = personRepository.Update(person);
            return Accepted(personResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = personRepository.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            var personResult = personRepository.Update(person);
            return Ok();
        }


    }
}
