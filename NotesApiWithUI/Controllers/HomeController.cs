using Microsoft.AspNetCore.Mvc;
using NotesApiWithUI.Models;
using NotesApiWithUI.Services;

namespace NotesApiWithUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteService _noteService;

        public HomeController(NoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            var notes = _noteService.GetAll();
            return View(notes);
        }

        [HttpPost]
        public IActionResult Add(Note note)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _noteService.Add(note);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _noteService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var note = _noteService.GetById(id);
            if (note == null) return NotFound();

            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note updatedNote)
        {
            if (!ModelState.IsValid) return View(updatedNote);

            var result = _noteService.Update(updatedNote.Id, updatedNote);
            if (result == null) return NotFound();

            return RedirectToAction("Index");
        }

    }
}