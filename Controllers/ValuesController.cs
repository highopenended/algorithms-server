using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.Models;


namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets all values
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new[] { "Retrieved Value From Server: 1", "Retrieved Value From Server: 2" });
        }


        /// <summary>
        /// Gets a specific value by id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> Get(int id)
        {
            if (int.TryParse(id.ToString(), out int n))
            {
                return Ok("Value for id: " + n);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Creates a new value
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] ValuesDto dto)
        {       
            _logger.LogInformation("------ Received value: {Value}", dto.Value);
            return CreatedAtAction(nameof(Get), new { id = 1 }, dto.Value);
        }


        /// <summary>
        /// Updates an existing value
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return NoContent();
        }


        /// <summary>
        /// Deletes a value
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
