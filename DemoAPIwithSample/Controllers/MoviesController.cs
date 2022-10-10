using DemoAPIwithSample.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using DemoAPIwithSample.Model;
using System.Linq;

namespace DemoAPIwithSample.Controllers
{
    public class MoviesController : Controller
    {
       // private readonly IMovieService _service;
        private readonly ILogger _logger;
        private IMovieService _service;

        public MoviesController(IMovieService service,ILogger logger)
        {
            this._service = service;
            this._logger= logger;
        }

        //GET api/Movies
       [HttpGet]
        public ActionResult<IEnumerable<Movies>> GetAll()
        {
            var items = _service.GetAll();
            return Ok(items);
        }

        //GET api/Movies/5
        [HttpGet("{id}")]
        public ActionResult<Movies> Get(Guid id)
        {
            var item = _service.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        //POST api/Movies
        [HttpPost]
        public ActionResult Post([FromBody] Movies value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        //DELETE api/Movies/5
        [HttpDelete("{id}")]
        public ActionResult RemoveMovie(Guid id)
        {
            var existingItem = _service.GetById(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.Remove(id);
            return Ok();
        }

    }
}
