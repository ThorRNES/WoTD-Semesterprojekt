using Microsoft.AspNetCore.Mvc;
using WorkOutToDO.Models;
using WorkOutToDO.Repos;
using WoTD_Semesterprojekt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WoTDController.Controllers
{
    [Route("wotd")]
    [ApiController]
    public class WoTDController : ControllerBase
    {
        private GenericRepo<Person> _repo;

        public WoTDController(GenericRepo<Person> repo)
        {
            _repo = repo;
        }

        // GET: api/<WoTDController>
        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/<WoTDController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<WoTDController>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person value)
        {
            Person person = _repo.Add(value);
            return CreatedAtAction((nameof(GetAll)), new { title = person.FName }, person);
        }

        // PUT api/<WoTDController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WoTDController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
