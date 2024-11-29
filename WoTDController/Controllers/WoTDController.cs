using Microsoft.AspNetCore.Mvc;
using WorkOutToDO.Models;
using WorkOutToDO.Repos;
using WoTD_Semesterprojekt;
using WoTD_Semesterprojekt.Models;
using WoTD_Semesterprojekt.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WoTDController.Controllers
{
    [Route("wotd")]
    [ApiController]
    public class WoTDController : ControllerBase
    {
        private readonly PersonRepo _repo;


        public WoTDController(PersonRepo repo)
        {
            _repo = repo;

        }

        [HttpPost("{id}/measurements")]
        public ActionResult AddMeasurement(int id, [FromBody] Measurement measurement)
        {
            if (measurement == null)
            {
                return BadRequest("Measurement data is null.");
            }

            var person = _repo.GetById(id);
            if (person == null)
            {
                return NotFound($"No person found with ID {id}.");
            }

            person.Measurements.Add(measurement);

            return Ok($"Measurement added successfully to person with ID {id}.");
        }
        // GET: api/<WoTDController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            //return new string[] { "value1", "value2" };
            return _repo.GetAll();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET api/<TrophyController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            if (id == 0) { return BadRequest("Id not recognized"); } 
            Person person = _repo.GetById(id);
            if (person == null)
            {
                return NotFound("person not found, id: " + id);
            }
            return Ok(person);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<WoTDController>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person value)
        {
            if (value == null)
            {
                return NotFound("Null person found");
            }
            Person person = _repo.Add(value);
            return CreatedAtAction((nameof(Get)), new { name = person.FName }, person);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // PUT api/<WoTDController>/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person value)
        {


                // Use the repository to update the person by ID
                Person person = _repo.GetById(id);
                if (person == null)
                {
                    return NotFound(new { message = "Person not found, id: " + id });
                }
            return Ok(person);

             
            

        }
        // DELETE api/<WoTDController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            Person person = _repo.GetById(id);
            if(person == null)
            {
                return NotFound("No such Id: " + id);
            }
            return Ok(person);
        }
    }
}

