using Microsoft.AspNetCore.Mvc;
using NotesApiWithUI.Models;
using NotesApiWithUI.Services;

namespace NotesApiWithUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NoteService _noteService;

        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_noteService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var note = _noteService.GetById(id);
            return note == null ? NotFound() : Ok(note);
        }

        [HttpPost]
        public IActionResult Add(Note note)
        {
            var createdNote = _noteService.Add(note);
            return CreatedAtAction(nameof(GetById), new { id = createdNote.Id }, createdNote);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _noteService.Delete(id);
            return result ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Note updatedNote)
        {
            var note = _noteService.Update(id, updatedNote);
            return note == null ? NotFound() : Ok(note);
        }
    }
}