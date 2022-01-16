using AareonTechnicalTest.Models;
using BusinessAccessLayer.Services;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        private readonly IRepository<Person> _Person;
        public PersonController(IRepository<Person> person, PersonService productService)
        {
            _personService = productService;
            _Person = person;
        }

        // GET: api/GetAll
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Person>> GetAllPersons()
        {
            return Ok(_personService.GetAllPersons());
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person =  _personService.GetPersonById(id);

            if (person == null)
            {
                return NotFound(id);
            }

            return Ok(person);
        }

        //Add Person
        [HttpPost("AddPerson")]
        public async Task<Object> AddPerson([FromBody] Person person)
        {
            try
            {
                await _personService.AddPerson(person);
                return Ok("Person was added");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //Update Person
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            try
            {
                // TODO this check is needed.
                //if (id != person.Id)
                //{
                //    return BadRequest("Person ID mismatch");
                //}
                var personToUpdate = _personService.GetPersonById(id);

                if (personToUpdate == null)
                {
                    return NotFound($"Person with Id {id} not found");
                }

                var result = _personService.UpdatePerson(id, person);
                return result ? Ok(id) : BadRequest($"Person with id {id} was not updated.");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error updating data");
            }

        }

        //Delete Person
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            try
            {         
                var person = _personService.GetPersonById(id);

                if (person == null)
                {
                    return NotFound(id);
                }

                bool result = _personService.DeletePerson(person);
            
                return result ? Ok(id) : BadRequest($"Person with id {id} was not deleted.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting person");
            }
        }        
    }
}
