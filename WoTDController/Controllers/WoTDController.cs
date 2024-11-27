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

        private readonly HttpClient _httpClient;  // Declare HttpClient

        public WoTDController(GenericRepo<Person> repo, HttpClient httpClient)
        {
            _repo = repo;
            _httpClient = httpClient;
        }

        [HttpGet("exercises")]
        public async Task<IActionResult> GetExercises()
        {
            try
            {
                // Create the HttpRequestMessage with the external API URL and muscle query parameter
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.api-ninjas.com/v1/exercises");

                // Add the API key to the headers of the request
                requestMessage.Headers.Add("X-Api-Key", "+dIZRhCnq8grOuytY/aTJg==6YnDIrNneZLxp1bw"); // Replace with your actual API key

                // Send the request asynchronously using HttpClient
                var response = await _httpClient.SendAsync(requestMessage);

                // Check if the response was successful (status code 200-299)
                if (!response.IsSuccessStatusCode)
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, $"Error retrieving exercises: {errorDetails}");
                }

                // Read the response content as a string
                var data = await response.Content.ReadAsStringAsync();

                // Return the response data (you can deserialize it if needed)
                return Ok(data); // You can also deserialize the data here if needed
            }
            catch (HttpRequestException ex)
            {
                // Handle errors if the request fails
                return StatusCode(500, "Error retrieving exercises: " + ex.Message);
            }
        }


        // GET: api/<WoTDController>
        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _repo.GetAll();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET api/<TrophyController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get([FromHeader] int id)
        {
            Person person = _repo.GetById(id);
            if (person == null)
            {
                return NotFound("Trophy not found, id: " + id);
            }
            return Ok(person);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<WoTDController>
        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person value)
        {
            Person person = _repo.Add(value);
            return CreatedAtAction((nameof(GetAll)), new { name = person.FName }, person);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // PUT api/<WoTDController>/5
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, [FromBody] Person value)
        {
            try
            {
                // Ensure that the ID in the URL matches the ID in the body of the request
                if (id != value.Id)
                {
                    return BadRequest(new { message = "ID mismatch: URL ID does not match Person's Id" });
                }

                // Use the repository to update the person by ID
                Person person = _repo.Update(value);
                if (person == null)
                {
                    return NotFound(new { message = "Person not found, id: " + id });
                }

                return Ok(person);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest("Invalid data provided.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest("Data out of range.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        // DELETE api/<WoTDController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

