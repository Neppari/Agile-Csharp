using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise_5._5.Models;
using Exercise_5._5.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercise_5._5.Controllers
{
    [Route("notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        // GET: <NoteController>
        [HttpGet]
        public List<Note> Get()
        {
            return MockNoteRepository.Instance.GetNotes();
        }

        [HttpPost]
        public Note Post([FromBody] Note note)
        {
            note.Id = MockNoteRepository.Instance.GetNotes().Count + 1;
            MockNoteRepository.Instance.GetNotes().Add(note);
            return note;
        }
    }
}
