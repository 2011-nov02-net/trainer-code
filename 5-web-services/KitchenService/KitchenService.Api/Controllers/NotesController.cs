using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using KitchenService.Api.Model;
using KitchenService.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitchenService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: api/notes
        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get([FromQuery] DateTime? since = null, [FromQuery] int count = -1)
        {
            if (count > 200)
            {
                return BadRequest("too many");
            }
            IEnumerable<Note> notes = _noteRepository.GetAll(since);
            if (count > -1)
            {
                notes = notes.Take(count);
            }
            return notes.ToList();
        }

        //// GET: api/notes/5.json
        //// GET: api/notes/5.xml
        //[HttpGet("{id}.{format}")]
        //[FormatFilter]

        // GET: api/notes/5
        [HttpGet("{id}")]
        public ActionResult<Note> GetById(int id)
        {
            if (_noteRepository.GetById(id) is Note note)
            {
                return note;
            }
            return NotFound();

            //var contentResult = new ContentResult
            //{
            //    StatusCode = StatusCodes.Status200OK, // or just 200
            //    ContentType = MediaTypeNames.Application.Json, // "application/json"
            //    Content = $"{{ \"id\": {id} }}"
            //};
            //return contentResult;

            //return StatusCode(200, );

            //return Json(new { id = id });
        }

        // TODO: support adding with tags
        // POST: api/notes
        [HttpPost]
        [Consumes("application/xml")] // we won't even route to this method if the incoming media type doesn't match
        [Produces("application/xml")] // will override the http Accept header when objectresult decides how to serialize.
        public IActionResult Post([FromBody] Note note)
        {
            _noteRepository.Add(note);
            // id is now set
            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        // TODO: support changing the tags
        // PUT: api/notes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Note note)
        {
            // successful update for PUT returns 204 No Content with empty body, or 200 OK
            if (_noteRepository.GetById(id) is Note oldNote)
            {
                oldNote.DateModified = DateTime.Now;
                oldNote.Author = note.Author;
                oldNote.IsPublic = note.IsPublic;
                oldNote.Text = note.Text;
                return NoContent();
                //return StatusCode(204);
            }
            return NotFound();
        }

        // DELETE: api/notes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // successful DELETE returns 204 No Content with empty body
            if (_noteRepository.GetById(id) is Note note)
            {
                _noteRepository.Remove(note);
                return NoContent();
            }
            return NotFound();
        }
    }
}
